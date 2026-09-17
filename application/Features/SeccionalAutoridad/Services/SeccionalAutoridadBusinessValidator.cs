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
                throw new BadRequestException("La FechaVigenciaDesde debe ser anterior o igual a FechaVigenciaHasta.");
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

            // Obtener autoridades existentes para la seccional (solo activos)
            var existingAuthorities = await unitOfWork.SeccionalAutoridadRepository.GetSeccionalAutoridadesBySeccional(entidad.SeccionalId, soloVigentes: false, soloActivos: true);

            // Excluir el id si corresponde (Update)
            var authorities = existingAuthorities.AsEnumerable();
            if (excludeId.HasValue)
            {
                authorities = authorities.Where(x => x.Id != excludeId.Value);
            }

            // 2. Conflicto por mismo cargo (SeccionalId + RefCargosId) con solapamiento
            var cargoConflict = authorities.Any(x =>
                x.RefCargosId == entidad.RefCargosId &&
                start <= (x.FechaVigenciaHasta ?? DateTime.MaxValue) &&
                end >= (x.FechaVigenciaDesde ?? DateTime.MinValue));

            // 6. Regla de reemplazo: no permitir igualdad de fechas (touching) para mismo cargo
            var touchingExisting = false;
            if (entidad.FechaVigenciaDesde.HasValue)
            {
                touchingExisting = authorities.Any(x =>
                    x.RefCargosId == entidad.RefCargosId &&
                    x.FechaVigenciaHasta.HasValue &&
                    x.FechaVigenciaHasta.Value.Date == entidad.FechaVigenciaDesde.Value.Date);
            }

            // 3. Conflicto por mismo afiliado (SeccionalId + AfiliadoId) con solapamiento
            var afiliadoConflict = authorities.Any(x =>
                x.AfiliadoId == entidad.AfiliadoId &&
                start <= (x.FechaVigenciaHasta ?? DateTime.MaxValue) &&
                end >= (x.FechaVigenciaDesde ?? DateTime.MinValue));

            if (isReactivation)
            {
                if (cargoConflict || afiliadoConflict)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_CONFLICT",
                        "No se puede reactivar la autoridad porque su período se solapa con otra autoridad activa.");
                }
            }
            else
            {
                if (cargoConflict)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_CONFLICT",
                        "El cargo ya está ocupado durante el período de vigencia indicado.",
                        "RefCargosId");
                }

                if (touchingExisting)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_CONFLICT",
                        "La nueva FechaVigenciaDesde debe ser posterior a la FechaVigenciaHasta de la autoridad anterior.",
                        "FechaVigenciaDesde");
                }

                if (afiliadoConflict)
                {
                    throw new ConflictException("SECCIONAL_AUTORIDAD_CONFLICT",
                        "El afiliado ya posee otra autoridad durante el período de vigencia indicado.",
                        "AfiliadoId");
                }
            }
        }
    }
}