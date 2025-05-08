using CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AccesoOspreraSpecification : BaseSpecification<AccesoOsprera>
    {
        public AccesoOspreraSpecification(GetAccesoOspreraListQuery query) : base()
        {           
            //Agrego tablas relacionadas
           // AgregarIncludes(a => a.Include(e => e.EstadoSolicitud!)); // en que estado aparece el afiliado cuando pasa del formulario a afiliado?
           // AgregarIncludes(a => a.Include(e => e.Seccional!));
            //AgregarIncludes(a => a.Include(e => e.SeccionalAfiliado!).ThenInclude(r => r.SeccionalLocalidad).ThenInclude(s => s.RefLocalidad));
            //AgregarIncludes(a => a.Include(e => e.Sexo!));
            //AgregarIncludes(a => a.Include(e => e.Actividad!));
            //AgregarIncludes(a => a.Include(e => e.Puesto!));
            //AgregarIncludes(a => a.Include(e => e.RefLocalidad!));
            //AgregarIncludes(a => a.Include(e => e.RefLocalidad!.Provincia!));
            //AgregarIncludes(a => a.Empresa!);
            //AgregarIncludes(a => a.Include(e => e.Nacionalidad!));
            //AgregarIncludes(a => a.Include(e => e.EstadoCivil!));
            //AgregarIncludes(a => a.Include(e => e.TipoDocumento!));

            //AgregarIncludes(a => a.Include(e => e.Afiliado!));           

            // Filtros
           // if (!query.NroAfiliadoHasta.HasValue) { query.NroAfiliadoHasta = query.NroAfiliado; };
            //if (!query.FechaIngresoHasta.HasValue) { query.FechaIngresoHasta = query.FechaIngreso; };

            SetCriteria(x => (!query.CUITTitular.HasValue || x.CUITTitular == query.CUITTitular) &&
            (!query.DniPaciente.HasValue || x.DniPaciente == query.DniPaciente) &&
            (string.IsNullOrEmpty(query.NombreyApellido) || x.NombreyApellido!.Contains(query.NombreyApellido)) &&
            //(string.IsNullOrEmpty(query.Seccional) || x.SeccionalAfiliado!.Descripcion!.Contains(query.Seccional)) &&
            (!query.Fecha.HasValue || (x.Fecha.Value.Date >= query.Fecha.Value.Date)) &&
            (string.IsNullOrEmpty(query.MedioGestion) || x.MedioGestion!.Contains(query.MedioGestion)) &&
            // (!query.EstadoSolicitudId.HasValue || x.EstadoSolicitudId == query.EstadoSolicitudId) &&
            //(!query.EmpresaId.HasValue || x.EmpresaId == query.EmpresaId) &&
            //(!query.RefMotivoBajaId.HasValue || x.RefMotivoBajaId == query.RefMotivoBajaId) &&

            ((!query.CreatedDateDesde.HasValue || !query.CreatedDateHasta.HasValue) || (x.CreatedDate.Value.Date >= query.CreatedDateDesde && x.CreatedDate.Value.Date <= query.CreatedDateHasta)) &&
            ((query.AmbitoTodos != null || query.AmbitoSeccionales == null) || query.AmbitoSeccionales.Ids.Contains(x.SeccionalId)) 
            //((query.AmbitoTodos != null || query.AmbitoDelegaciones == null) || query.AmbitoDelegaciones.Ids.Contains(x.SeccionalAfiliado.RefDelegacionId))
            //((query.AmbitoTodos != null || query.AmbitoProvincias == null) || query.AmbitoProvincias.Ids.Contains(x.RefLocalidad.ProvinciaId))
            );

            //Paginacion
            ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);

            //Ordenamiento            
            if (!string.IsNullOrEmpty(query.Sort))
            {
                AddOrder(query.Sort);                
            }
        }

        public AccesoOspreraSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            //AgregarIncludes(a => a.Include(e => e.EstadoSolicitud!));
            //AgregarIncludes(a => a.Include(e => e.SeccionalAfiliado!));
            //AgregarIncludes(a => a.Include(e => e.Sexo!));
            //AgregarIncludes(a => a.Include(e => e.Actividad!));
           // AgregarIncludes(a => a.Include(e => e.Puesto!));
            //AgregarIncludes(a => a.Include(e => e.RefLocalidad!));
           // AgregarIncludes(a => a.Include(e => e.RefLocalidad!.Provincia!));
           // AgregarIncludes(a => a.Include(e => e.Nacionalidad!));
           // AgregarIncludes(a => a.Include(e => e.EstadoCivil!));
           // AgregarIncludes(a => a.Include(e => e.TipoDocumento!));
        }

        
    }
}
