using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using FluentValidation;

namespace CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;

//public class AmbitoValidator : AbstractValidator<Ambito>
//{
//    public AmbitoValidator()
//    {
//        RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe especificar el Tipo");
//        RuleFor(x => x.Id).NotEmpty().WithMessage("Debe especificar AmbitoId");
//    }

//}

public class GetGestionOspreraListQueryValidator : AbstractValidator<GetGestionOspreraListQuery>
{
    public GetGestionOspreraListQueryValidator()
    {
        //RuleForEach(x => x.Ambitos).SetValidator(new AmbitoValidator());
    }
}
