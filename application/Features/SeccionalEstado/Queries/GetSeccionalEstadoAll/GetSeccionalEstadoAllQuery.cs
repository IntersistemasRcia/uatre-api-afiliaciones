using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoAll;

public class GetSeccionalEstadoAllQuery : IRequest<IReadOnlyList<SeccionalEstadoResponse>>
{
}
