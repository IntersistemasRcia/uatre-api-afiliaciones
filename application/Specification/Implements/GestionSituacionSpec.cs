using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements;

public class GestionSituacionSpec : BaseSpecification<GestionSituacion>
{
    public GestionSituacionSpec(int estadoId) : base(x => x.GestionEstadoId == estadoId)
    {

    }
}
