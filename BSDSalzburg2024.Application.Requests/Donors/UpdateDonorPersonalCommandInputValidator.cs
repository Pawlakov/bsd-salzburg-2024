namespace BSDSalzburg2024.Application.Requests.Donors;

using BSDSalzburg2024.Application.Requests.Validation;
using FluentValidation;

public class UpdateDonorPersonalCommandInputValidator
    : AbstractInputValidator<UpdateDonorPersonalCommand>
{
    public UpdateDonorPersonalCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.FamilyName)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.GivenName)
            .NotEmpty()
            .WithMessage("Required");
    }
}
