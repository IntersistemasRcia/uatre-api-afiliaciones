using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Domain;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoSpecification(GetAfiliadoListQuery query) : base(x => 
            (!query.CUIL.HasValue || x.CUIL == query.CUIL) &&
            (!query.NroAfiliado.HasValue || x.NroAfiliado == query.NroAfiliado) &&
            (string.IsNullOrEmpty(query.Nombre) || x.Nombre!.Contains(query.Nombre!)) &&
            (!query.Documento.HasValue || x.Documento == query.Documento) &&
            (string.IsNullOrEmpty(query.Seccional) || x.Seccional!.Descripcion!.Contains(query.Seccional!)) &&
            (!query.FechaIngreso.HasValue || x.FechaIngreso == query.FechaIngreso) &&
            (!query.FechaEgreso.HasValue || x.FechaEgreso == query.FechaEgreso) &&
            (!query.EstadoSolicitudId.HasValue || x.EstadoSolicitudId == query.EstadoSolicitudId) &&
            (!query.EmpresaId.HasValue || x.EmpresaId == query.EmpresaId)
        )
        {            

            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud!);
            AgregarIncludes(a => a.Seccional!);
            AgregarIncludes(a => a.Sexo!);
            AgregarIncludes(a => a.Actividad!);
            AgregarIncludes(a => a.Puesto!);
            AgregarIncludes(a => a.RefLocalidad!);
            AgregarIncludes(a => a.RefLocalidad!.Provincia!);
            //AgregarIncludes(a => a.Empresa!);
            AgregarIncludes(a => a.Nacionalidad!);
            AgregarIncludes(a => a.EstadoCivil!);
            AgregarIncludes(a => a.TipoDocumento!);

            //Paginacion
            ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);

            //Ordenamiento            
            if (!string.IsNullOrEmpty(query.Sort))
            {
                AddOrder(query.Sort);                
            }
        }

        public AfiliadoSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud!);
            AgregarIncludes(a => a.Seccional!);
            AgregarIncludes(a => a.Sexo!);
            AgregarIncludes(a => a.Actividad!);
            AgregarIncludes(a => a.Puesto!);
            AgregarIncludes(a => a.RefLocalidad!);
            AgregarIncludes(a => a.RefLocalidad!.Provincia!);
            //AgregarIncludes(a => a.Empresa!);
            AgregarIncludes(a => a.Nacionalidad!);
            AgregarIncludes(a => a.EstadoCivil!);
            AgregarIncludes(a => a.TipoDocumento!);
        }

        
    }
}
