namespace CleanArchitecture.Application.Models.APIAudit;

public class AuditoriaCambioDatos
{
    public required string Usuario { get; set; } = string.Empty;
    public required string Tabla { get; set; }
    public required Guid TablaIdentificador { get; set; }
    public required string Accion { get; set; }
    public DateTime Timestamp { get; set; }
    public required string Cambios { get; set; }
}
