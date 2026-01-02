using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using FluentValidation;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList;

//public class AmbitoValidator : AbstractValidator<Ambito>
//{
//    public AmbitoValidator()
//    {
//        RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe especificar el Tipo");
//        RuleFor(x => x.Id).NotEmpty().WithMessage("Debe especificar AmbitoId");
//    }

//}

public class GetAfiliadoFAListQueryValidator : AbstractValidator<GetAfiliadoFAListQuery>
{
    public GetAfiliadoFAListQueryValidator()
    {
        //RuleForEach(x => x.Ambitos).SetValidator(new AmbitoValidator());
    }
}
