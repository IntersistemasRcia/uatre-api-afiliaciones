param(
  [Parameter(Mandatory=$true)][string]$PublishDir,
  [Parameter(Mandatory=$true)][string]$SitePath,
  [Parameter(Mandatory=$true)][string]$SiteName,
  [Parameter(Mandatory=$true)][string]$AppPool,
  [Parameter(Mandatory=$true)][string]$BackupDir,
  [int]$KeepBackups = 5
)

function Log { param($m) Write-Host "$(Get-Date -Format o) - $m" }

Log "Starting IIS deployment (safe mode)"

# Resolve absolute paths
try { $PublishDirAbs = (Resolve-Path -Path $PublishDir -ErrorAction Stop).ProviderPath } catch { $PublishDirAbs = $PublishDir }
try { $SitePathAbs = (Resolve-Path -Path $SitePath -ErrorAction Stop).ProviderPath } catch { $SitePathAbs = $SitePath }
try { $BackupDirAbs = (Resolve-Path -Path $BackupDir -ErrorAction SilentlyContinue).ProviderPath } catch { $BackupDirAbs = $BackupDir }

Log "PublishDir resolved to: $PublishDirAbs"
Log "SitePath resolved to:    $SitePathAbs"
if ($BackupDirAbs) { Log "BackupDir resolved to:   $BackupDirAbs" }

# Safety checks to avoid wiping runner
$runnerIndicators = @()
if ($env:RUNNER_WORKSPACE) { $runnerIndicators += $env:RUNNER_WORKSPACE }
if ($env:RUNNER_TEMP) { $runnerIndicators += $env:RUNNER_TEMP }
if ($env:RUNNER_TOOL_CACHE) { $runnerIndicators += $env:RUNNER_TOOL_CACHE }
$runnerIndicators += "actions-runner"
$runnerIndicators += "_work"

foreach ($ri in $runnerIndicators | Where-Object { $_ }) {
  if ($SitePathAbs -and $SitePathAbs.ToLower().Contains($ri.ToLower())) {
    Log "ERROR: SitePath '$SitePathAbs' appears to be inside runner workspace/installation ('$ri'). Aborting to avoid wiping runner."
    throw "Unsafe SitePath detected: $SitePathAbs"
  }
  if ($BackupDirAbs -and $BackupDirAbs.ToLower().Contains($ri.ToLower())) {
    Log "ERROR: BackupDir '$BackupDirAbs' appears to be inside runner workspace/installation ('$ri'). Aborting to avoid writing inside runner."
    throw "Unsafe BackupDir detected: $BackupDirAbs"
  }
}

# Ensure publish folder exists and is not empty
if (-not (Test-Path $PublishDirAbs)) {
  throw "PublishDir not found: $PublishDirAbs"
}
$pFiles = Get-ChildItem -Path $PublishDirAbs -Recurse -Force -ErrorAction SilentlyContinue | Where-Object { -not $_.PSIsContainer }
if (-not $pFiles -or $pFiles.Count -eq 0) {
  Log "ERROR: Publish directory is empty: $PublishDirAbs. Aborting deployment to avoid destructive mirror."
  throw "Publish directory is empty"
}

# Diagnostic listing (short)
Log "Publish directory contains $($pFiles.Count) file(s)."
$pFiles | ForEach-Object {
  if ($_.FullName.Length -gt 260) { Log "WARNING: long path ($($_.FullName.Length)) - $($_.FullName)" }
}

Import-Module WebAdministration -ErrorAction Stop

# Ensure backup dir exists (create outside of runner if possible)
$timestamp = (Get-Date).ToString('yyyyMMdd-HHmmss')
$releaseBackup = Join-Path $BackupDir $timestamp
New-Item -ItemType Directory -Force -Path $releaseBackup | Out-Null

Log "Backing up current site content from '$SitePathAbs' to '$releaseBackup'"
# Copy current content to backup (exclude backup folder if it's inside site)
$absBackupDir = (Resolve-Path -Path $BackupDir -ErrorAction SilentlyContinue).ProviderPath
Get-ChildItem -Path $SitePathAbs -Force | Where-Object {
  if ($absBackupDir) { -not ($_.FullName.StartsWith($absBackupDir)) } else { $true }
} | ForEach-Object {
  $target = Join-Path $releaseBackup $_.Name
  if ($_.PSIsContainer) { Copy-Item -Path $_.FullName -Destination $target -Recurse -Force -ErrorAction Stop }
  else { Copy-Item -Path $_.FullName -Destination $target -Force -ErrorAction Stop }
}

# Stop App Pool
Log "Stopping app pool '$AppPool'"
Try {
  Stop-WebAppPool -Name $AppPool -ErrorAction Stop
} Catch {
  Log "Warning: Could not stop app pool '$AppPool' - $_"
}

# --- Preserve existing web.config and appsettings.json in the target site ---
$excludeFiles = @()
$targetWebConfig = Join-Path $SitePathAbs 'web.config'
$targetAppSettings = Join-Path $SitePathAbs 'appsettings.json'

if (Test-Path $targetWebConfig) {
  Log "Found existing web.config at target. Will exclude from overwrite."
  $excludeFiles += 'web.config'
}
if (Test-Path $targetAppSettings) {
  Log "Found existing appsettings.json at target. Will exclude from overwrite."
  $excludeFiles += 'appsettings.json'
}
if ($excludeFiles.Count -gt 0) {
  Log ("Files to exclude from deployment: " + ($excludeFiles -join ', '))
} else {
  Log "No existing web.config or appsettings.json found at target; publish files (if present) will be copied."
}

# Deploy using robocopy (robust for Windows)
$robocopy = Join-Path $env:windir 'System32\Robocopy.exe'
if (-not (Test-Path $robocopy)) { throw "Robocopy not found at $robocopy" }

Log "Deploying files from '$PublishDirAbs' to '$SitePathAbs' with robocopy (mirror)"
# Build robocopy arguments, add /XF to exclude files that must be preserved
$robocopyArgs = @($PublishDirAbs, $SitePathAbs, '/MIR', '/COPY:DAT', '/R:2', '/W:2', '/MT:8')
if ($excludeFiles.Count -gt 0) {
  $robocopyArgs += '/XF'
  $robocopyArgs += $excludeFiles
}

# Execute robocopy with constructed args
& $robocopy @robocopyArgs | Out-Host
$rc = $LASTEXITCODE
Log "Robocopy exit code: $rc"

# Interpret robocopy exit codes: 0-7 are success/partial success, >=8 is failure
if ($rc -ge 8) {
  Log "ERROR: Robocopy failed with exit code $rc (>=8). Aborting deployment."
  throw "Robocopy failed with exit code $rc"
} else {
  Log "Robocopy completed with non-fatal exit code $rc. Treating as success."
}

# Start App Pool
Log "Starting app pool '$AppPool'"
Try {
  Start-WebAppPool -Name $AppPool -ErrorAction Stop
} Catch {
  Log "Warning: Could not start app pool '$AppPool' - $_"
}

# Clean old backups
Log "Cleaning old backups, keep $KeepBackups"
if (Test-Path $BackupDir) {
  $dirs = Get-ChildItem -Path $BackupDir -Directory | Sort-Object Name -Descending
  $toRemove = $dirs | Select-Object -Skip $KeepBackups
  foreach ($d in $toRemove) {
    Log "Removing old backup $($d.FullName)"
    Remove-Item -Path $d.FullName -Recurse -Force -ErrorAction SilentlyContinue
  }
}

Log "Deployment finished successfully"

# Ensure process exits with code 0 so Actions step is successful when robocopy exit < 8
exit 0