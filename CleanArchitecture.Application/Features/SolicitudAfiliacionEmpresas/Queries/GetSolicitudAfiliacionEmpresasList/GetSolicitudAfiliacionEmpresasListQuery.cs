using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasList
{
    public class GetSolicitudAfiliacionEmpresasListQuery : IRequest<List<SolicitudAfiliacionEmpresasVm>>
    {
        public bool? VerDetalles { get; set; } = true;
        public GetSolicitudAfiliacionEmpresasListQuery()
        {
            
        }
    }
}
