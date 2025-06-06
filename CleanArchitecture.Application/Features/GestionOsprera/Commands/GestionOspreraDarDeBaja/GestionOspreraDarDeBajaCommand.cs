using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraDarDeBaja;

public class GestionOspreraDarDeBajaCommand : IRequest<int>
{
    public int Id { get; set; }
    public string DeletedObs { get; set; }
}
