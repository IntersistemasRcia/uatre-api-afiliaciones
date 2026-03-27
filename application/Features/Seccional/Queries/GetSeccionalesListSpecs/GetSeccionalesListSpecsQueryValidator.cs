using FluentValidation;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;

public class AmbitoValidator : AbstractValidator<Ambito>
{
    public AmbitoValidator()
    {
        //RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe especificar el Tipo");
        //RuleFor(x => x.Id).NotEmpty().WithMessage("Debe especificar AmbitoId");
    }
    
}

public class GetSeccionalesListSpecsQueryValidator : AbstractValidator<GetSeccionalesListSpecsQuery>
{
    public GetSeccionalesListSpecsQueryValidator()
    {
        //RuleForEach(x => x.Ambitos).SetValidator(new AmbitoValidator());        
    }
}
