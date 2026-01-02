using CleanArchitecture.Application.Features.GestionOsprera.Queries;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.Identity.Client;

namespace CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList
{
    public class GetGestionOspreraListQuery : IRequest<Pagination<GestionOspreraVm>>
    {
        private int _pageIndex { get; set; } = 1;
        private const int maxPageSize = 50;
        private int _pageSize = 50;

        public DateTime? Fecha { get; set; }
        public string? UsuarioId { get; set; }
        public int? SeccionalId { get; set; }
        public int? GestionEstadoId { get; set; }
        public int? GestionSituacionId { get; set; }
        public int? GestionRubroId { get; set; }
        public int? GestionSubRubroId { get; set; }
        public long? CUITTitular { get; set; }
        public string? NombreTitular { get; set; }
        public  string? ApellidoTitular { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? TelefonoContacto2 { get; set; }
        public string? EmailContacto { get; set; }
        public string? EmailContacto2 { get; set; }
        public bool? ElPacienteEsTitular { get; set; }
        public  int TipoDocumentoId { get; set; }
        public long? DniPaciente { get; set; }
        public string? NombrePaciente { get; set; }
        public string? ApellidoPaciente { get; set; }
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
        public Ambito? AmbitoTodos { get; set; }
        public Ambito? AmbitoDelegaciones { get; set; }
        public Ambito? AmbitoSeccionales { get; set; }
        public Ambito? AmbitoProvincias { get; set; }
        public DateTime? CreatedDateDesde { get; set; }
        public DateTime? CreatedDateHasta { get; set; }

        public string? Sort { get; set; }
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value;
        }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value >= maxPageSize ? maxPageSize : value;
        }

        public GetGestionOspreraListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }

        public int GetPageIndex() { return _pageIndex; }

        public int GetPageSize() { return _pageSize; }
    }
}
