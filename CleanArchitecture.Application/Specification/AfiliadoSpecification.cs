using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification
{
    public class AfiliadoSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoSpecification(GetAfiliadoListQuery pParams)
            : base(x =>
                (!pParams.EstadoSolicitudId.HasValue || x.EstadoSolicitudId == pParams.EstadoSolicitudId)
            )
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud);
            AgregarIncludes(a => a.Seccional);
            AgregarIncludes(a => a.Sexo);
            AgregarIncludes(a => a.Actividad);
            AgregarIncludes(a => a.Puesto);
            AgregarIncludes(a => a.Provincia);
            AgregarIncludes(a => a.Empresa);

            //Paginacion
            ApplyPaging(pParams.PageSize * (pParams.PageIndex-1), pParams.PageSize );

            //Ordenamiento
            if (!string.IsNullOrEmpty(pParams.Sort))
            {
                switch (pParams.Sort)
                {                    
                    case "cuil":
                        AddOrderByDescending(a => a.CUIL);
                        break;

                    case "nombre":
                        AddOrderBy(a => a.Nombre);
                        break;

                    default:
                        AddOrderBy(a => a.Id);
                        break;
                }
            }
        }

        public AfiliadoSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud);
            AgregarIncludes(a => a.Seccional);
            AgregarIncludes(a => a.Sexo);
            AgregarIncludes(a => a.Actividad);
        }
    }
}
