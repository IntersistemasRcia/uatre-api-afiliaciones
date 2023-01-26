using CleanArchitecture.Application.Features.Padron.Queries.GetPadronList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification
{
    public class PadronSpecification : BaseSpecification<Padron>
    {
        public PadronSpecification(GetPadronListQuery pParams)
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

            //Paginacion
            ApplyPaging(pParams.PageSize * (pParams.PageIndex-1), pParams.PageSize );

            //Ordenamiento
            if (!string.IsNullOrEmpty(pParams.Sort))
            {
                switch (pParams.Sort)
                {
                    case "cuit":
                        AddOrderBy(a => a.CUIT);
                        break;

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

        public PadronSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud);
            AgregarIncludes(a => a.Seccional);
            AgregarIncludes(a => a.Sexo);
            AgregarIncludes(a => a.Actividad);
        }
    }
}
