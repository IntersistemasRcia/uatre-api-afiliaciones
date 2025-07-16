using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoSpecification(GetAfiliadoListQuery query) : base()
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

            // Filtros
            if (!query.NroAfiliadoHasta.HasValue) { query.NroAfiliadoHasta = query.NroAfiliado; };
            if (!query.FechaIngresoHasta.HasValue) { query.FechaIngresoHasta = query.FechaIngreso; };

            SetCriteria(x => (!query.CUIL.HasValue || x.CUIL == query.CUIL) &&
            (!query.NroAfiliado.HasValue || (x.NroAfiliado >= query.NroAfiliado && x.NroAfiliado <= query.NroAfiliadoHasta)) &&
            (string.IsNullOrEmpty(query.Nombre) || x.Nombre!.Contains(query.Nombre)) &&
            (!query.Documento.HasValue || x.Documento == query.Documento) &&
            (string.IsNullOrEmpty(query.Seccional) || x.Seccional!.Descripcion!.Contains(query.Seccional) || x.Seccional!.Codigo!.Contains(query.Seccional)) &&
            //(!query.SeccionalEstadoId.HasValue || x.Seccional!.SeccionalEstadoId == query.SeccionalEstadoId) && //se agrega a pedido de mauricio por el tema de los AMBITOS DELEGACIONES; Deben mostrar afiliados con seccionales Normalizadas. Hoy 09/06/25 se quita este filtro que era exclusivo de ambito Delegaciones
            ((query.AmbitoTodos == null || query.AmbitoTodos.Ids.FirstOrDefault() == 0) 
            || (x.Seccional!.SeccionalEstado!.Descripcion.Contains("NORMALIZADA") || x.Seccional!.SeccionalEstado!.Descripcion.Contains("TRANSITORIA") || x.Seccional!.SeccionalEstado!.Descripcion.Contains("SIN COMISION"))) &&
            (!query.SoloActivos || x.DeletedDate == null) &&
            (!query.FechaIngreso.HasValue || (x.FechaIngreso.Value.Date >= query.FechaIngreso.Value.Date && x.FechaIngreso.Value.Date <= query.FechaIngresoHasta.Value.Date)) &&
            (!query.FechaEgreso.HasValue || x.FechaEgreso.Value.Date == query.FechaEgreso.Value.Date) &&
            (!query.EstadoSolicitudId.HasValue || x.EstadoSolicitudId == query.EstadoSolicitudId) &&
            (!query.EmpresaId.HasValue || x.EmpresaId == query.EmpresaId) &&
            (!query.RefMotivoBajaId.HasValue || x.RefMotivoBajaId == query.RefMotivoBajaId) &&
            (!query.SoloActivos || x.DeletedDate == null) &&
            ((!query.CreatedDateDesde.HasValue || !query.CreatedDateHasta.HasValue) || (x.CreatedDate.Value.Date >= query.CreatedDateDesde && x.CreatedDate.Value.Date <= query.CreatedDateHasta)) &&
            (query.AmbitoSeccionalesActivas.Ids.Count == 0 || query.AmbitoSeccionalesActivas.Ids.Contains(x.SeccionalId)) &&
            ((query.AmbitoTodos != null || query.AmbitoProvincias == null) || query.AmbitoProvincias.Ids.Contains(x.RefLocalidad.ProvinciaId))
            );

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
