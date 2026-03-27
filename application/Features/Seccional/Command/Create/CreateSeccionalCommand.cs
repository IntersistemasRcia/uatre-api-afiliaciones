using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Command.Create
{
    public class CreateSeccionalCommand : IRequest<CreateSeccionalVm>
    {
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Domicilio { get; set; }
        public string? Observaciones { get; set; }
        public int SeccionalEstadoId { get; set; }
        public int RefDelegacionId { get; set; }
        public int RefLocalidadesId { get; set; }
        public string? Email { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

        public TimeOnly? HorarioAtencion1Desde { get; set; }
        public TimeOnly? HorarioAtencion1Hasta { get; set; }
        public TimeOnly? HorarioAtencion2Desde { get; set; }
        public TimeOnly? HorarioAtencion2Hasta { get; set; }
        public string? Telefono { get; set; }
        public string? TelefonoSecretarioGeneral { get; set; }

        //public IReadOnlyCollection<CreateSeccionalContactoCommand>? Contactos { get; set; }
        public ICollection<CreateSeccionalAutoridad>? SeccionalAutoridades { get; set; }
        public ICollection<CreateSeccionalLocalidad>? SeccionalLocalidad { get; set; }
        public ICollection<DocumentacionEntidad>? Documentacion { get; set; } 
    }

    //public class CreateSeccionalContactoCommand
    //{
    //    public string? Tipo { get; set; }
    //    public string? Detalle { get; set; }
    //}

    public class CreateSeccionalAutoridad
    {
        public int AfiliadoId { get; set; }
        public int RefCargosId { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaVigenciaDesde { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; } = null;
    }

    public class CreateSeccionalLocalidad
    {
        public int RefLocalidadId { get; set; }      
    }
}
