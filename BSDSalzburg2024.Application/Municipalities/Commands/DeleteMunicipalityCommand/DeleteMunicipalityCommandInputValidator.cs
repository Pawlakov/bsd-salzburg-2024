// <copyright file="DeleteMunicipalityCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.DeleteMunicipalityCommand;

using BSDSalzburg2024.Application.Validation;
using FluentValidation;

public class DeleteMunicipalityCommandInputValidator
    : AbstractInputValidator<DeleteMunicipalityCommand>
{
    public DeleteMunicipalityCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");
    }
}