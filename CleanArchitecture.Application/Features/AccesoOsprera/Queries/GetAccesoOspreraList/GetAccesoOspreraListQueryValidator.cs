using CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using FluentValidation;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList;

//public class AmbitoValidator : AbstractValidator<Ambito>
//{
//    public AmbitoValidator()
//    {
//        RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe especificar el Tipo");
//        RuleFor(x => x.Id).NotEmpty().WithMessage("Debe especificar AmbitoId");
//    }

//}

public class GetAccesoOspreraListQueryValidator : AbstractValidator<GetAccesoOspreraListQuery>
{
    public GetAccesoOspreraListQueryValidator()
    {
        //RuleForEach(x => x.Ambitos).SetValidator(new AmbitoValidator());
    }
}
