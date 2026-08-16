// <copyright file="DeleteLocationCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Domain;
using FluentValidation;

internal class DeleteLocationCommandDataValidator
    : AbstractDataValidator<DeleteLocationCommand>
{
    internal DeleteLocationCommandDataValidator(BsdDatabaseContext context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.Locations.Where(x => x.Id == id).Any())
            .WithMessage("IdInvalid");
    }
}
