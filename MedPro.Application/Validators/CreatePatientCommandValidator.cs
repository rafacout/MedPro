using FluentValidation;
using MedPro.Application.Commands.Patient.CreatePatient;

namespace MedPro.Application.Validators;

public class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty().WithMessage("First Name is required")
            .MaximumLength(100).WithMessage("First Name must not exceed 100 characters");
        
        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("Last Name is required")
            .MaximumLength(100).WithMessage("Last Name must not exceed 100 characters");
    }
}