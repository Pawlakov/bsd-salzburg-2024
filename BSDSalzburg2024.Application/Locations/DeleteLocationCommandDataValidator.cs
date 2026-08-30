// <copyright file="DeleteLocationCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Domain.Entities;

using FluentValidation;

internal class DeleteLocationCommandDataValidator
    : AbstractDataValidator<DeleteLocationCommand>
{
    internal DeleteLocationCommandDataValidator(IBaseRepository<Location, string> context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.AsQueryable().Any(x => x.Id == id))
            .WithMessage("IdInvalid");
    }
}
