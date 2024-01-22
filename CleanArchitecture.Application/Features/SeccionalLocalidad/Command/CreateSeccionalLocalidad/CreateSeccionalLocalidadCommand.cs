using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.CreateSeccionalLocalidad;

public class CreateSeccionalLocalidadCommand : IRequest<SeccionalLocalidadVm>
{
    public int RefLocalidadId { get; set; }
    public int SeccionalId { get; set; }
}
