using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalSpecification : BaseSpecification<Seccional>
    {
        public SeccionalSpecification(GetSeccionalesListSpecsQuery query)
            : base(x =>
                (string.IsNullOrEmpty(query.Provincia) || x.RefLocalidades.Provincia.Nombre.Contains(query.Provincia)) &&
                (!query.ProvinciaId.HasValue || x.RefLocalidades.ProvinciaId == query.ProvinciaId) &&
                (string.IsNullOrEmpty(query.Localidad) || x.RefLocalidades.Nombre.Contains(query.Localidad)) &&
                (!query.LocalidadId.HasValue|| x.RefLocalidadesId == query.LocalidadId) &&
                (!query.CodigoPostal.HasValue || x.RefLocalidades.CodPostal == query.CodigoPostal) &&
                (!query.RefDelegacionId.HasValue || x.RefDelegacionId == query.RefDelegacionId) &&
                (!query.SoloActivos || x.DeletedDate == null) &&
                ((query.AmbitoTodos != null || query.AmbitoSeccionales == null) || query.AmbitoSeccionales.Ids.Contains(x.Id)) &&
                ((query.AmbitoTodos != null || query.AmbitoDelegaciones == null) || query.AmbitoDelegaciones.Ids.Contains(x.RefDelegacionId)) &&
                ((query.AmbitoTodos != null || query.AmbitoProvincias == null) || query.AmbitoProvincias.Ids.Contains(x.RefLocalidades.ProvinciaId))
            )
        {
            AgregarIncludes(x => x.Include(e => e.SeccionalLocalidad!).ThenInclude(er => er.RefLocalidad));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!).ThenInclude(rl => rl.Provincia!));
            AgregarIncludes(x => x.Include(e => e.SeccionalContacto!));
            AgregarIncludes(x => x.Include(e => e.SeccionalAutoridades!));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!));
            AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));

            //Paginacion
            ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);
        }

        public SeccionalSpecification(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(x => x.Include(e => e.SeccionalLocalidad!).ThenInclude(er => er.RefLocalidad));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!).ThenInclude(rl => rl.Provincia!));
            AgregarIncludes(x => x.Include(e => e.SeccionalContacto!));
            AgregarIncludes(x => x.Include(e => e.SeccionalAutoridades!));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!));
            AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));
        }

        public SeccionalSpecification()
        {
            AgregarIncludes(x => x.Include(e => e.SeccionalLocalidad!).ThenInclude(er => er.RefLocalidad));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!).ThenInclude(rl => rl.Provincia!));
            AgregarIncludes(x => x.Include(e => e.SeccionalContacto!));
            AgregarIncludes(x => x.Include(e => e.SeccionalAutoridades!));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!));
            AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));
        }
    }
}

