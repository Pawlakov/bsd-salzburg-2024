// <copyright file="CreateLocationCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.CreateLocationCommand;

using BSDSalzburg2024.Application.Validation;
using FluentValidation;

public class CreateLocationCommandInputValidator
    : AbstractInputValidator<CreateLocationCommand>
{
    public CreateLocationCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.Id)
            .MaximumLength(8)
            .WithMessage("IdTooLong");
    }
}