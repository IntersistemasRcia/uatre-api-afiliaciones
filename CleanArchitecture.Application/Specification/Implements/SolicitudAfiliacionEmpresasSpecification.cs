using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasList;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SolicitudAfiliacionEmpresasSpecification : BaseSpecification<SolicitudAfiliacionEmpresas>
    {
        public SolicitudAfiliacionEmpresasSpecification(GetSolicitudAfiliacionEmpresasListSpecsQuery query)
            : base(x =>
                (string.IsNullOrEmpty(query.Seccional) || x.Seccional.Descripcion.Contains(query.Seccional)) &&
                (!query.SeccionalId.HasValue || x.SeccionalId == query.SeccionalId) &&
                (!query.EstadoSolicitudId.HasValue || x.EstadoSolicitudId == query.EstadoSolicitudId) &&
                (!query.EmpresaId.HasValue || x.EmpresaId == query.EmpresaId) &&
                (x.DeletedDate == null) &&
                ((query.AmbitoTodos != null || query.AmbitoSeccionales == null) || query.AmbitoSeccionales.Ids.Contains(x.SeccionalId)) &&
                ((query.AmbitoTodos != null || query.AmbitoDelegaciones == null) || query.AmbitoDelegaciones.Ids.Contains(x.Seccional.RefDelegacionId)) &&
                ((query.AmbitoTodos != null || query.AmbitoProvincias == null) || query.AmbitoProvincias.Ids.Contains(x.Seccional.RefLocalidades.ProvinciaId))
            )
        {
            if (query.VerDetalles == true)
            {
                AgregarIncludes(x => x.Include(e => e.SolicitudAfiliacionEmpresasDetalle!));
            }

            
            AgregarIncludes(x => x.Include(e => e.Seccional!));
            AgregarIncludes(x => x.Include(e => e.EstadoSolicitud!));

            //Sorting 
            if (!string.IsNullOrEmpty(query.Sort))
            {
                var startsWith = query.Sort.Substring(0, 1);
                var sortBy = query.Sort.Substring(1).ToLower();

                switch (sortBy)
                {
                    case "fecha":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.Fecha);
                        }
                        else
                        {
                            AddOrderBy(x => x.Fecha);
                        }
                        break;
                    case "id":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.Id);
                        }
                        else
                        {
                            AddOrderBy(x => x.Id);
                        }
                        break;

                    case "estadosolicitud":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.EstadoSolicitudId);
                        }
                        else
                        {
                            AddOrderBy(x => x.EstadoSolicitudId);
                        }
                        break;
                    default:
                        break;
                }
            }

            //Paginacion
            ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);
        }

        public SolicitudAfiliacionEmpresasSpecification(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(x => x.Include(e => e.Seccional!));
            AgregarIncludes(x => x.Include(e => e.EstadoSolicitud!));
        }

        public SolicitudAfiliacionEmpresasSpecification(GetSolicitudAfiliacionEmpresasListQuery query) : base(x =>
        (x.DeletedDate == null))
        {
            if (query.VerDetalles == true)
            {
                AgregarIncludes(x => x.Include(e => e.SolicitudAfiliacionEmpresasDetalle!));
            }

            AgregarIncludes(x => x.Include(e => e.Seccional!));
            AgregarIncludes(x => x.Include(e => e.EstadoSolicitud!));
        }
    }
}

