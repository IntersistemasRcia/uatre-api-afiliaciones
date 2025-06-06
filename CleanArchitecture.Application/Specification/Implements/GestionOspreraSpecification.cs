using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class GestionOspreraSpecification : BaseSpecification<GestionOsprera>
    {
        public GestionOspreraSpecification(GetGestionOspreraListQuery query) : base()
        {           
            //Agrego tablas relacionadas           
            //AgregarIncludes(a => a.Include(e => e.GestionAreaOsprera!));
            //AgregarIncludes(a => a.Include(e => e.GestionEstado!));
            //AgregarIncludes(a => a.Include(e => e.GestionSituacion!));
            //AgregarIncludes(a => a.Include(e => e.GestionAreaOsprera!));
            //AgregarIncludes(a => a.Include(e => e.GestionAreaOsprera!));

            // Filtros
           // if (!query.NroAfiliadoHasta.HasValue) { query.NroAfiliadoHasta = query.NroAfiliado; };
            //if (!query.FechaIngresoHasta.HasValue) { query.FechaIngresoHasta = query.FechaIngreso; };

            SetCriteria(x => (!query.CUITTitular.HasValue || x.CUITTitular == query.CUITTitular) &&
            (!query.DniPaciente.HasValue || x.DniPaciente == query.DniPaciente) &&
            (string.IsNullOrEmpty(query.NombreTitular) || x.NombreTitular!.Contains(query.NombreTitular)) &&
            (string.IsNullOrEmpty(query.ApellidoTitular) || x.ApellidoTitular!.Contains(query.ApellidoTitular)) &&
            (string.IsNullOrEmpty(query.NombrePaciente) || x.NombrePaciente!.Contains(query.NombrePaciente)) &&
            (string.IsNullOrEmpty(query.ApellidoPaciente) || x.ApellidoPaciente!.Contains(query.ApellidoPaciente)) &&
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

        public GestionOspreraSpecification(int pId) : base(x => x.Id == pId)
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
