using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Queries
{
    public class AccesoOspreraVm : EntidadAuditable
    {

        public DateTime Fecha { get; set; }
        public string? UsuarioId { get; set; }
        public int? SeccionalId { get; set; }
        public long? CUITTitular { get; set; }
        public int? TipoDocumentoId { get; set; }
        public long? DniPaciente { get; set; }
        public string? NombreyApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? SexoId { get; set; }
        public string? MedioGestion { get; set; }
        public string? Telefono { get; set; }
        public string? ResultadoLlamada { get; set; }
        public string? DireccionesEmailDestino { get; set; }
        public string? Texto { get; set; }
        public DateTime? FechaEnvioMail { get; set; }
        public string? RespuestaEnvioEmail { get; set; }
        public Guid? Guid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedObs { get; set; }
    }
}
