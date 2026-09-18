using System;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Services
{
    public class SeccionalAutoridadBusinessValidator : ISeccionalAutoridadBusinessValidator
    {
        private readonly IUnitOfWork unitOfWork;

        public SeccionalAutoridadBusinessValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task ValidateAsync(CleanArchitecture.Domain.SeccionalAutoridad entidad, int? excludeId = null, bool isReactivation = false)
        {
            // 5. Fecha Desde <= Fecha Hasta.
            if (entidad.FechaVigenciaDesde.HasValue && entidad.FechaVigenciaHasta.HasValue &&
                entidad.FechaVigenciaDesde.Value.Date > entidad.FechaVigenciaHasta.Value.Date)
            {
                throw new BadRequestException("La Fecha de Vigencia Desde debe ser menor o igual que la Fecha de Vigencia Hasta.");
            }

            // Validar existencia de Seccional y Afiliado usando el repositorio genérico
            var seccional = await unitOfWork.Repository<CleanArchitecture.Domain.Seccional>().GetByIdAsync(entidad.SeccionalId);
            if (seccional == null)
                throw new BadRequestException($"SeccionalId {entidad.SeccionalId} no existe.");

            var afiliado = await unitOfWork.Repository<CleanArchitecture.Domain.Afiliado>().GetByIdAsync(entidad.AfiliadoId);
            if (afiliado == null)
                throw new BadRequestException($"AfiliadoId {entidad.AfiliadoId} no existe.");

            var refCargo = await unitOfWork.RefRepository.GetRefCargoById(entidad.RefCargosId);
            if (refCargo == null)
                throw new BadRequestException($"RefCargosId {entidad.RefCargosId} no existe.");

            // Normalizar fechas para comparación (null => extremos)
            var start = entidad.FechaVigenciaDesde?.Date ?? DateTime.MinValue.Date;
            var end = entidad.FechaVigenciaHasta?.Date ?? DateTime.MaxValue.Date;

            // Obtener autoridades existentes para la seccional (incluye históricas y dadas de baja)
            var existingAuthorities = await unitOfWork.SeccionalAutoridadRepository.GetSeccionalAutoridadesBySeccional(entidad.SeccionalId, soloVigentes: false, soloActivos: false);

            // Excluir el id si corresponde (Update)
            var authorities = existingAuthorities.AsEnumerable();
            if (excludeId.HasValue)
            {
                authorities = authorities.Where(x => x.Id != excludeId.Value);
            }

            // ===== Nueva condición solicitada (INCLUSIVA) para autoridades anteriores dadas de baja =====
            // Aplicar sólo cuando:
            // - autoridad.DeletedDate.HasValue == true
            // - misma SeccionalId y mismo RefCargosId (la consulta ya filtra por seccional)
            // - no es el mismo Id (ya excluido)
            if (entidad.FechaVigenciaDesde.HasValue)
            {
                var deletedConflicts = authorities
                    .Where(x => x.RefCargosId == entidad.RefCargosId && x.DeletedDate.HasValue);

                foreach (var autoridad in deletedConflicts)
                {
                    // La regla ahora es inclusiva: nueva.FechaVigenciaDesde.Date >= autoridad.DeletedDate.Value.Date
                    if (entidad.FechaVigenciaDesde.Value.Date < autoridad.DeletedDate.Value.Date)
                    {
                        throw new ConflictException(
                            "SECCIONAL_AUTORIDAD_CARGO_DELETED_DATE_CONFLICT",
                            "La Fecha de Vigencia Desde debe ser igual o posterior a la Fecha de Baja de la autoridad anterior.",
                            "FechaVigenciaDesde"
                        );
                    }
                }
            }
            // =========================================================================================

            // 2. Conflicto por mismo cargo (SeccionalId + RefCargosId) con solapamiento (considera autoridades activas e históricas con fechas)
            var cargoConflict = authorities
                .Where(x => x.RefCargosId == entidad.RefCargosId && x.DeletedDate == null) // aquí consideramos solo los activos para solapamiento normal
                .Any(x =>
                    start <= (x.FechaVigenciaHasta ?? DateTime.MaxValue.Date) &&
                    end >= (x.FechaVigenciaDesde ?? DateTime.MinValue.Date)
                );

            // 6. Regla de reemplazo: no permitir igualdad de fechas (touching) para mismo cargo (autoridades activas)
            var touchingExisting = false;
            if (entidad.FechaVigenciaDesde.HasValue)
            {
                touchingExisting = authorities
                    .Where(x => x.RefCargosId == entidad.RefCargosId && x.DeletedDate == null && x.FechaVigenciaHasta.HasValue)
                    .Any(x => x.FechaVigenciaHasta.Value.Date == entidad.FechaVigenciaDesde.Value.Date);
            }

            // 3. Conflicto por mismo afiliado (SeccionalId + AfiliadoId) con solapamiento (solo autoridades activas)
            var afiliadoConflict = authorities
                .Where(x => x.DeletedDate == null)
                .Any(x =>
                    x.AfiliadoId == entidad.AfiliadoId &&
                    start <= (x.FechaVigenciaHasta ?? DateTime.MaxValue.Date) &&
                    end >= (x.FechaVigenciaDesde ?? DateTime.MinValue.Date)
                );

            if (isReactivation)
            {
                if (cargoConflict || afiliadoConflict)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_REACTIVATION_CONFLICT",
                        "No se puede reactivar la autoridad porque su período se solapa con otra autoridad activa.");
                }
            }
            else
            {
                if (cargoConflict)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_CARGO_DATE_CONFLICT",
                        "El cargo ya está ocupado durante el período de vigencia indicado.",
                        "RefCargosId");
                }

                if (touchingExisting)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_CARGO_DATE_CONFLICT",
                        "La nueva FechaVigenciaDesde debe ser posterior a la FechaVigenciaHasta de la autoridad anterior.",
                        "FechaVigenciaDesde");
                }

                if (afiliadoConflict)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_AFILIADO_DATE_CONFLICT",
                        "El afiliado ya posee otra autoridad durante el período de vigencia indicado.",
                        "AfiliadoId");
                }
            }
        }
    }
}