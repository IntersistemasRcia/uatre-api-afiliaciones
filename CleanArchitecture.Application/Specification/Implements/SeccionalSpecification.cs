using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList;
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
                (string.IsNullOrEmpty(query.Codigo) || x.Codigo.Contains(query.Codigo)) &&
                (string.IsNullOrEmpty(query.Descripcion) || x.Descripcion.Contains(query.Descripcion)) &&
                (!query.SeccionalEstadoId.HasValue || x.SeccionalEstadoId == query.SeccionalEstadoId) &&
				(!query.SoloActivos || x.DeletedDate == null ) &&
                (!query.SoloActivos || x.SeccionalAbsorbenteId == 0) &&
                ((query.AmbitoTodos != null || query.AmbitoSeccionales == null) || query.AmbitoSeccionales.Ids.Contains(x.Id)) &&
                ((query.AmbitoTodos != null || query.AmbitoDelegaciones == null) || query.AmbitoDelegaciones.Ids.Contains(x.RefDelegacionId)) &&
                ((query.AmbitoTodos != null || query.AmbitoProvincias == null) || query.AmbitoProvincias.Ids.Contains(x.RefLocalidades.ProvinciaId))
            )
        {
            if (query.VerSeccionalesLocalidades == true)
            {
                AgregarIncludes(x => x.Include(e => e.SeccionalLocalidad!).ThenInclude(er => er.RefLocalidad));
            }

            AgregarIncludes(x => x.Include(e => e.RefLocalidades!).ThenInclude(rl => rl.Provincia!));
            AgregarIncludes(x => x.Include(e => e.SeccionalContacto!));
            AgregarIncludes(x => x.Include(e => e.SeccionalAutoridades!));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!));
            AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));

            //Sorting 
            if (!string.IsNullOrEmpty(query.Sort))
            {
                var startsWith = query.Sort.Substring(0, 1);
                var sortBy = query.Sort.Substring(1).ToLower();

                switch (sortBy)
                {
                    case "codigo":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.Codigo);
                        }
                        else
                        {
                            AddOrderBy(x => x.Codigo);
                        }
                        break;

                    case "nombre":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.Descripcion);
                        }
                        else
                        {
                            AddOrderBy(x => x.Descripcion);
                        }
                        break;

                    case "estadoid":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.SeccionalEstadoId);
                        }
                        else
                        {
                            AddOrderBy(x => x.SeccionalEstadoId);
                        }
                        break;

                    case "delegacionid":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.RefDelegacionId);
                        }
                        else
                        {
                            AddOrderBy(x => x.RefDelegacionId);
                        }
                        break;

                    default:
                        break;
                }
            }

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

        public SeccionalSpecification(GetSeccionalesListQuery query) : base(x =>
        ((!query.SoloActivos.HasValue || query.SoloActivos == false) || x.DeletedDate == null) &&
        ((!query.SoloActivos.HasValue || query.SoloActivos == false) || x.SeccionalAbsorbenteId == 0) &&
        (!query.LocalidadId.HasValue || x.RefLocalidadesId == query.LocalidadId) &&
        (!query.ProvinciaId.HasValue || x.RefLocalidades.ProvinciaId == query.ProvinciaId))
        {
            if (query.VerSeccionalesLocalidades == true)
            {
                AgregarIncludes(x => x.Include(e => e.SeccionalLocalidad!).ThenInclude(er => er.RefLocalidad));                
            }

            AgregarIncludes(x => x.Include(e => e.RefLocalidades!).ThenInclude(rl => rl.Provincia!));
            AgregarIncludes(x => x.Include(e => e.SeccionalContacto!));
            AgregarIncludes(x => x.Include(e => e.SeccionalAutoridades!));
            AgregarIncludes(x => x.Include(e => e.RefLocalidades!));
            AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));
        }
    }
}

