using CleanArchitecture.Application.Features.Seccional.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasById;

public class GetSolicitudAfiliacionEmpresasByIdQuery : IRequest<SolicitudAfiliacionEmpresasVm>
{
    public int Id { get; set; }

    public GetSolicitudAfiliacionEmpresasByIdQuery(int id)
    {
        Id = id;
    }
}

