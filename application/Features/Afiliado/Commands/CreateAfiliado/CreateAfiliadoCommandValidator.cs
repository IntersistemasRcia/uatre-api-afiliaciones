using FluentValidation;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateAfiliadoCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(e => e.Nombre)
                .NotEmpty()
                .NotNull().WithMessage("{Nombre} no puede ser nulo");

            RuleFor(e => e.CUIL)
                .NotEmpty()
                .NotNull().WithMessage("{CUIL} no puede ser nulo");

        }
    }
}
