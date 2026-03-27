using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using FluentValidation;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;

public class AmbitoValidator : AbstractValidator<Ambito>
{
    public AmbitoValidator()
    {
        //RuleFor(x => x.Tipo).NotEmpty().WithMessage("Debe especificar el Tipo");
        //RuleFor(x => x.Id).NotEmpty().WithMessage("Debe especificar AmbitoId");
    }
    
}

public class GetSolicitudAfiliacionEmpresasListSpecsQueryValidator : AbstractValidator<GetSolicitudAfiliacionEmpresasListSpecsQuery>
{
    public GetSolicitudAfiliacionEmpresasListSpecsQueryValidator()
    {
        //RuleForEach(x => x.Ambitos).SetValidator(new AmbitoValidator());        
    }
}
