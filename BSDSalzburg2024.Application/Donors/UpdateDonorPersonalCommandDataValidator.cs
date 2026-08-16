namespace BSDSalzburg2024.Application.Donors;

using System.Linq;
using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Application.Validation;
using FluentValidation;

internal class UpdateDonorPersonalCommandDataValidator
    : AbstractDataValidator<UpdateDonorPersonalCommand>
{
    internal UpdateDonorPersonalCommandDataValidator(BsdDatabaseContext context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.Donors.Where(x => x.Id == id).Any())
            .WithMessage("IdInvalid");
    }
}