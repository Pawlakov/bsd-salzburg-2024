// <copyright file="DeleteLocationCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using BSDSalzburg2024.Application.Requests.Validation;
using FluentValidation;

public class DeleteLocationCommandInputValidator
    : AbstractInputValidator<DeleteLocationCommand>
{
    public DeleteLocationCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");
    }
}