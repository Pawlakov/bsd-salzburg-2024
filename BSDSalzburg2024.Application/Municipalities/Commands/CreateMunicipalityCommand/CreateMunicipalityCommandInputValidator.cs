// <copyright file="CreateMunicipalityCommandValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.CreateMunicipalityCommand;

using System.Linq;
using BSDSalzburg2024.Application.Models;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Data;
using FluentValidation;

public class CreateMunicipalityCommandInputValidator
    : AbstractInputValidator<CreateMunicipalityCommand>
{
    public CreateMunicipalityCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .NotEqual(0);

        this.RuleFor(command => command.PostalCode)
            .NotEmpty();

        this.RuleFor(command => command.PostalCode)
            .Must(c => c.All(x => char.IsDigit(x)));

        this.RuleFor(command => command.PostalCode)
            .MinimumLength(4)
            .MaximumLength(5);

        this.RuleFor(command => command.Country)
            .NotEmpty();

        this.RuleFor(command => command.Country)
            .Must(c => Country.GetFromIso(c) == null);

        this.RuleFor(command => command.Name)
            .NotEmpty();
    }
}
