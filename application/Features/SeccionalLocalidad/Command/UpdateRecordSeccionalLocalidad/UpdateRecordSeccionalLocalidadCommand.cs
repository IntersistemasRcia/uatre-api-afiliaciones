using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateRecordSeccionalLocalidad;

public class UpdateRecordSeccionalLocalidadCommand : IRequest<SeccionalLocalidadVm>
{
    public int Id { get; set; }
    public int SeccionalId { get; set; }
    public int RefLocalidadId { get; set; }    
}
