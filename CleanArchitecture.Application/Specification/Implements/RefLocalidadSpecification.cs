using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadSpecs;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements;

public class RefLocalidadSpecification : BaseSpecification<RefLocalidad>
{
    public RefLocalidadSpecification(GetRefLocalidadSpecsQuery query)
        : base(x =>              
            (!query.CodigoPostal.HasValue || x.CodPostal == query.CodigoPostal) &&
            (!query.CodigoPostalUATRE.HasValue || x.CodPostal.ToString().Contains(query.CodigoPostalUATRE.ToString())) &&
            (!query.ProvinciaId.HasValue || x.ProvinciaId == query.ProvinciaId) &&
            (!query.SoloActivos || x.DeletedDate == null)
        )
    {
        AgregarIncludes(r => r.Include(e => e.Provincia!));
    }

    public RefLocalidadSpecification(int pId) : base(x => x.Id == pId)
    {
        AgregarIncludes(r => r.Include(e => e.Provincia!));
    }
}
