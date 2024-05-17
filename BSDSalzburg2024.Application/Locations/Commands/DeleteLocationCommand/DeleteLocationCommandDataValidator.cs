// <copyright file="DeleteLocationCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.DeleteLocationCommand;

using System.Linq;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Data;
using FluentValidation;

public class DeleteLocationCommandDataValidator
    : AbstractDataValidator<DeleteLocationCommand>
{
    public DeleteLocationCommandDataValidator(BsdDatabaseContext context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.Locations.Where(x => x.Id == id).Any())
            .WithMessage("IdInvalid");
    }
}
