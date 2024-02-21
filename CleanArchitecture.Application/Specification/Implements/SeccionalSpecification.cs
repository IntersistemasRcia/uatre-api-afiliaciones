using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalSpecification : BaseSpecification<Seccional>
    {
        public SeccionalSpecification(GetSeccionalesListSpecsQuery query)
            : base(x =>
                (string.IsNullOrEmpty(query.Provincia) || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Provincia.Nombre == query.Provincia).Any()) &&
                (!query.ProvinciaId.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Provincia.Id == query.ProvinciaId).Any()) &&
                (string.IsNullOrEmpty(query.Localidad) || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Nombre == query.Localidad).Any()) &&
                (!query.LocalidadId.HasValue|| x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Id == query.LocalidadId).Any()) &&
                (!query.CodigoPostal.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.CodPostal == query.CodigoPostal).Any()) &&
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

