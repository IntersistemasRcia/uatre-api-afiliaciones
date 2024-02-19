using CleanArchitecture.Application.Features.Seccional.Command.Create;
using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Command.Update;

public class UpdateSeccionalCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public string? Domicilio { get; set; }
    public string? Observaciones { get; set; }
    public int SeccionalEstadoId { get; set; }
    public int RefDelegacionId { get; set; }
    public int RefLocalidadesId { get; set; }
    public string? Email { get; set; }
    public ICollection<CreateSeccionalAutoridad>? SeccionalAutoridades { get; set; }
    public ICollection<CreateSeccionalLocalidad>? SeccionalLocalidad { get; set; }
    public ICollection<DocumentacionEntidad>? Documentacion { get; set; }
}