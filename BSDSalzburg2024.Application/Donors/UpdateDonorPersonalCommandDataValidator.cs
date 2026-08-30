namespace BSDSalzburg2024.Application.Donors;

using System.Linq;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Donors;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Domain.Entities;

using FluentValidation;

internal class UpdateDonorPersonalCommandDataValidator
    : AbstractDataValidator<UpdateDonorPersonalCommand>
{
    internal UpdateDonorPersonalCommandDataValidator(IBaseRepository<Donor, int> context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.AsQueryable().Any(x => x.Id == id))
            .WithMessage("IdInvalid");
    }
}