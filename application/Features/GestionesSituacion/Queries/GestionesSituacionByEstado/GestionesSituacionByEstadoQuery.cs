using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesSituacion.Queries.GestionesSituacionByEstado;

public class GestionesSituacionByEstadoQuery : IRequest<List<IdDescripcionVm>>
{
    public int GestionEstadoId { get; set; }
}
