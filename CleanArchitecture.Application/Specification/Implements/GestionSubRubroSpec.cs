using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements;

public class GestionSubRubroSpec : BaseSpecification<GestionSubRubro>
{
    public GestionSubRubroSpec(int rubroId) : base(x => x.GestionRubroId == rubroId)
    {
        
    }
}
