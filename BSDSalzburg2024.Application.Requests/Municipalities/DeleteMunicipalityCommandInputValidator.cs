// <copyright file="DeleteMunicipalityCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using BSDSalzburg2024.Application.Requests.Validation;
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