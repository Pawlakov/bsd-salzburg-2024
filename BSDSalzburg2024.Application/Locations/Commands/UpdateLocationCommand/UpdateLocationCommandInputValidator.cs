// <copyright file="UpdateLocationCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.UpdateLocationCommand;

using BSDSalzburg2024.Application.Validation;
using FluentValidation;

public class UpdateLocationCommandInputValidator
    : AbstractInputValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");
    }
}
