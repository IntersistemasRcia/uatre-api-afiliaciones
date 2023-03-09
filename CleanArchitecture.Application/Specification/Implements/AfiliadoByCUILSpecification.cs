using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoByCUILSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoByCUILSpecification(GetAfiliadoByCUILQuery pParams)
            : base(x =>
                x.CUIL == pParams.CUIL
            )
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud);
            AgregarIncludes(a => a.Seccional);
            AgregarIncludes(a => a.Sexo);
            AgregarIncludes(a => a.Actividad);
            AgregarIncludes(a => a.Puesto);
            AgregarIncludes(a => a.RefLocalidad);
            AgregarIncludes(a => a.RefLocalidad!.Provincia!);
            AgregarIncludes(a => a.Empresa);
            AgregarIncludes(a => a.Nacionalidad);
            AgregarIncludes(a => a.EstadoCivil);
            AgregarIncludes(a => a.TipoDocumento);
        }

        public AfiliadoByCUILSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud);
            AgregarIncludes(a => a.Seccional);
            AgregarIncludes(a => a.Sexo);
            AgregarIncludes(a => a.Actividad);
            AgregarIncludes(a => a.Puesto);
            AgregarIncludes(a => a.RefLocalidad);
            AgregarIncludes(a => a.RefLocalidad.Provincia);
            AgregarIncludes(a => a.Empresa);
            AgregarIncludes(a => a.Nacionalidad);
            AgregarIncludes(a => a.EstadoCivil);
            AgregarIncludes(a => a.TipoDocumento);
        }
    }
}
