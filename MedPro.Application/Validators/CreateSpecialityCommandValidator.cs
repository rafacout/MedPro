using FluentValidation;
using MedPro.Application.Commands.CreateSpeciality;

namespace MedPro.Application.Validators;

public class CreateSpecialityCommandValidator : AbstractValidator<CreateSpecialityCommand>
{
    public CreateSpecialityCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 50 characters");
        
        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters");
    }
}