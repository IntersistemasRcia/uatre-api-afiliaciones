using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Features.Seccional.Command.Reactivar;

public class ReactivarCommand : IRequest<int>
{
    public int Id { get; set; }

    public int SeccionalEstadoId { get; set; }
}
