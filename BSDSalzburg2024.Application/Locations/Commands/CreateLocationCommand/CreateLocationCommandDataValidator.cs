// <copyright file="CreateLocationCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.CreateLocationCommand;

using System.Linq;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Data;
using FluentValidation;

public class CreateLocationCommandDataValidator
    : AbstractDataValidator<CreateLocationCommand>
{
    public CreateLocationCommandDataValidator(BsdDatabaseContext context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => !context.Locations.Where(x => x.Id == id).Any())
            .WithMessage("IdCollision");
    }
}
