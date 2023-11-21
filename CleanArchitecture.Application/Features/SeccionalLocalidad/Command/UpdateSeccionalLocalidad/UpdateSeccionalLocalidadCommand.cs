using CleanArchitecture.Application.Features.Seccional.Command.Create;
using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateSeccionalLocalidad;

public class UpdateSeccionalLocalidadCommand : IRequest<int>
{
    public int SeccionalId { get; set; }
    public ICollection<CreateSeccionalLocalidad>? SeccionalLocalidad { get; set; }
}
