using MediatR;

namespace CleanArchitecture.Application.Features.GestionesSubRubro.Queries.GestionesSubRubroByRubro;

public class GestionesSubRubroByRubroQuery : IRequest<List<GestionSubRubroVm>>
{
    public GestionesSubRubroByRubroQuery(int gestionRubroId)
    {
        GestionRubroId = gestionRubroId;
    }
    public int GestionRubroId { get; set; }
}
