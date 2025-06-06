using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraReactivar;

public class GestionOspreraReactivarCommand : IRequest<int>
{
    public int Id { get; set; }
}
