using CleanArchitecture.Application.Features.AccesoOsprera.Queries;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList
{
    public class GetAccesoOspreraListQuery : IRequest<Pagination<AccesoOspreraVm>>
    {
        private int _pageIndex { get; set; } = 1;
        private const int maxPageSize = 50;
        private int _pageSize = 50;

        public DateTime? Fecha { get; set; }
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

        public GetAccesoOspreraListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }

        public int GetPageIndex() { return _pageIndex; }

        public int GetPageSize() { return _pageSize; }
    }
}
