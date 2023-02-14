using CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByCPList;
using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Specification
{
    public class DDJJUatreSpecification : BaseSpecification<DDJJUatre>
    {
        public DDJJUatreSpecification(GetDDJJUatreByCUILListQuery pParams)
            : base(x => x.CUIL == pParams.CUIL)
        {
            AgregarIncludes(r => r.Empresa);
        }

        public DDJJUatreSpecification(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(r => r.Empresa);
        }
    }
}
