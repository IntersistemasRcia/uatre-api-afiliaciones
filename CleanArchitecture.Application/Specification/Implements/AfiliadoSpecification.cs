using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoSpecification(GetAfiliadoListQuery query) : base(x => 
            (!query.CUIL.HasValue || x.CUIL == query.CUIL) &&
            (!query.NroAfiliado.HasValue || x.NroAfiliado == query.NroAfiliado) &&
            (string.IsNullOrEmpty(query.Nombre) || x.Nombre!.Contains(query.Nombre)) &&
            (!query.Documento.HasValue || x.Documento == query.Documento) &&
            (string.IsNullOrEmpty(query.Seccional) || x.Seccional!.Descripcion!.Contains(query.Seccional)) &&
            (!query.FechaIngreso.HasValue || x.FechaIngreso == query.FechaIngreso) &&
            (!query.FechaEgreso.HasValue || x.FechaEgreso == query.FechaEgreso) &&
            (!query.EstadoSolicitudId.HasValue || x.EstadoSolicitudId == query.EstadoSolicitudId) &&
            (!query.EmpresaId.HasValue || x.EmpresaId == query.EmpresaId) &&
            (!query.SoloActivos || x.DeletedDate == null)
        )
        {            

            //Agrego tablas relacionadas
            AgregarIncludes(a => a.Include(e => e.EstadoSolicitud!));
            AgregarIncludes(a => a.Include(e => e.Seccional!));
            AgregarIncludes(a => a.Include(e => e.Seccional!).ThenInclude(r => r.SeccionalLocalidad).ThenInclude(s => s.RefLocalidad));
            AgregarIncludes(a => a.Include(e => e.Sexo!));
            AgregarIncludes(a => a.Include(e => e.Actividad!));
            AgregarIncludes(a => a.Include(e => e.Puesto!));
            AgregarIncludes(a => a.Include(e => e.RefLocalidad!));
            AgregarIncludes(a => a.Include(e => e.RefLocalidad!.Provincia!));
            //AgregarIncludes(a => a.Empresa!);
            AgregarIncludes(a => a.Include(e => e.Nacionalidad!));
            AgregarIncludes(a => a.Include(e => e.EstadoCivil!));
            AgregarIncludes(a => a.Include(e => e.TipoDocumento!));

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
            AgregarIncludes(a => a.Include(e => e.EstadoSolicitud!));
            AgregarIncludes(a => a.Include(e => e.Seccional!));
            AgregarIncludes(a => a.Include(e => e.Sexo!));
            AgregarIncludes(a => a.Include(e => e.Actividad!));
            AgregarIncludes(a => a.Include(e => e.Puesto!));
            AgregarIncludes(a => a.Include(e => e.RefLocalidad!));
            AgregarIncludes(a => a.Include(e => e.RefLocalidad!.Provincia!));
            AgregarIncludes(a => a.Include(e => e.Nacionalidad!));
            AgregarIncludes(a => a.Include(e => e.EstadoCivil!));
            AgregarIncludes(a => a.Include(e => e.TipoDocumento!));
        }

        
    }
}
