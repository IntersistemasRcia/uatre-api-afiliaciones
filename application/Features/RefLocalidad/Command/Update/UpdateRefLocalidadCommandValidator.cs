using FluentValidation;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Update;

public class UpdateRefLocalidadCommandValidator : AbstractValidator<UpdateRefLocalidadCommand>
{
    public UpdateRefLocalidadCommandValidator()
    {
        RuleFor(e => e.CodPostal)
                .NotEmpty()
                .NotNull().WithMessage("{CodPostal} no puede ser 0");

        RuleFor(e => e.Nombre)
            .NotEmpty()
            .NotNull().WithMessage("{Nombre} no puede ser nulo");

        RuleFor(e => e.ProvinciaId)
            .NotEmpty()
            .NotNull().WithMessage("{ProvinciaId} no puede ser nulo");
    }
}
