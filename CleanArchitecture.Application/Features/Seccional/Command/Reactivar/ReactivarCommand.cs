using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Features.Seccional.Command.Reactivar;

public class ReactivarCommand : IRequest<int>
{
    public int Id { get; set; }

    [RegularExpression("^Normalizada$|^Transitoria$|^Acefala$|^Fusionada$|^Activa$|^Inactiva$", ErrorMessage = "Valor NO Aceptado")]
    public string? Estado { get; set; }
}
