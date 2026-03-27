using CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements;

public class ProvinciasGetAllSpec : BaseSpecification<Provincia>
{
    public ProvinciasGetAllSpec(GetProvinciasListQuery query) : base()
    {
        AgregarIncludes(x => x.Include(e => e.Seccional));   
    }        
}
