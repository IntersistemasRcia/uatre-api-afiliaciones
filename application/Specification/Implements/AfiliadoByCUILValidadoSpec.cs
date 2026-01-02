using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUILValidado;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoByCUILValidadoSpec : BaseSpecification<Afiliado>
    {
        public AfiliadoByCUILValidadoSpec(GetAfiliadoByCUILValidadoQuery pParams, bool buscarPorCuilValidado)
            : base(x =>
                (buscarPorCuilValidado && x.CUILValidado == pParams.CUIL) ||
                (!buscarPorCuilValidado && x.CUIL == pParams.CUIL)
            )
        {
            if (pParams.IncludeRelatedTables)
            {
                //Agrego tablas relacionadas
                AgregarIncludes(a => a.Include(e => e.EstadoSolicitud));
                AgregarIncludes(a => a.Include(e => e.Seccional));
                AgregarIncludes(a => a.Include(e => e.Sexo));
                AgregarIncludes(a => a.Include(e => e.Actividad));
                AgregarIncludes(a => a.Include(e => e.Puesto));
                AgregarIncludes(a => a.Include(e => e.RefLocalidad));
                AgregarIncludes(a => a.Include(e => e.RefLocalidad!.Provincia!));
                //AgregarIncludes(a => a.Empresa);
                AgregarIncludes(a => a.Include(e => e.Nacionalidad));
                AgregarIncludes(a => a.Include(e => e.EstadoCivil));
                AgregarIncludes(a => a.Include(e => e.TipoDocumento));
            }            
        }
    }
}
