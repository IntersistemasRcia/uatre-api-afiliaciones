using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using FluentValidation;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;

//public class AmbitoValidator : AbstractValidator<Ambito>
//{
//    public AmbitoValidator()
//    {
//        RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe especificar el Tipo");
//        RuleFor(x => x.Id).NotEmpty().WithMessage("Debe especificar AmbitoId");
//    }

//}

public class GetAfiliadoListQueryValidator : AbstractValidator<GetAfiliadoListQuery>
{
    public GetAfiliadoListQueryValidator()
    {
        RuleForEach(x => x.Ambitos).SetValidator(new AmbitoValidator());
    }
}
