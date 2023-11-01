using MediatR;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;

public class GetSeccionalesListSpecsQuery : IRequest<List<SeccionalVm>>
{
    public string? Provincia { get; set; }
    public int? ProvinciaId { get; set; }
    public string? Localidad { get; set; }
    public int? LocalidadId { get; set; }
    public int? CodigoPostal { get; set; }
    public bool SoloActivos { get; set; } = true;
    public ICollection<Ambito> Ambitos { get; set; }

    public GetSeccionalesListSpecsQuery()
    {
        Ambitos = new List<Ambito>();
    }
}

public class Ambito
{
    public string Tipo { get; set; }
    public int Id { get; set; }
}
