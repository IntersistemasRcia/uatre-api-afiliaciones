using CleanArchitecture.Application.Features.Seccional.Command.Create;
using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateSeccionalLocalidad;

public class UpdateSeccionalLocalidadCommand : IRequest<int>
{
    public int SeccionalId { get; set; }
    public ICollection<RefLocalidadIdList>? SeccionalLocalidad { get; set; }
}

public class RefLocalidadIdList
{
    public int RefLocalidadId { get; set; }
}
