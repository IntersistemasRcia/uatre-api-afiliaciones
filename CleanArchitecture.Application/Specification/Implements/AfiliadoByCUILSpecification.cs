using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoByCUILSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoByCUILSpecification(GetAfiliadoByCUILQuery pParams)
            : base(x =>
                x.CUIL == pParams.CUIL
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

        public AfiliadoByCUILSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.Include(e => e.EstadoSolicitud));
            AgregarIncludes(a => a.Include(e => e.Seccional));
            AgregarIncludes(a => a.Include(e => e.Sexo));
            AgregarIncludes(a => a.Include(e => e.Actividad));
            AgregarIncludes(a => a.Include(e => e.Puesto));
            AgregarIncludes(a => a.Include(e => e.RefLocalidad));
            AgregarIncludes(a => a.Include(e => e.RefLocalidad.Provincia));
            AgregarIncludes(a => a.Include(e => e.Nacionalidad));
            AgregarIncludes(a => a.Include(e => e.EstadoCivil));
            AgregarIncludes(a => a.Include(e => e.TipoDocumento));
        }
    }
}
