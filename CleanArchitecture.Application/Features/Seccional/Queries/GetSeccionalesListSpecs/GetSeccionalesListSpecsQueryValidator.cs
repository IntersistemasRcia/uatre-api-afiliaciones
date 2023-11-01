using FluentValidation;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;

public class GetSeccionalesListSpecsQueryValidator : AbstractValidator<GetSeccionalesListSpecsQuery>
{
    public GetSeccionalesListSpecsQueryValidator()
    {
        RuleFor(x => x.Ambitos).NotNull().NotEmpty().WithMessage("Debe especificar el Ambito");
        RuleFor(x => x.Ambitos.Select(p => p.Tipo)).NotEmpty().WithMessage("Debe especificar el Tipo");
        RuleFor(x => x.Ambitos.Select(p => p.Id)).NotEmpty().WithMessage("Debe especificar AmbitoId");
    }
}
