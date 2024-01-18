using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Create;

public class CreateRefLocalidadCommand : IRequest<RefLocalidadVm>
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public int CodPostal { get; set; }
    public string LitProvincia { get; set; }
    public string NombreCompleto { get; set; }
    public string Tipo { get; set; }
    public int ProvinciaId { get; set; }
}
