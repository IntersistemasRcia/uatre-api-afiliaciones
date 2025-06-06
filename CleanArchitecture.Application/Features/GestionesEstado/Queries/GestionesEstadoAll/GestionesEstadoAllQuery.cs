using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesEstado.Queries.GestionesEstadoAll;

public class GestionesEstadoAllQuery : IRequest<List<IdDescripcionVm>>
{
}
