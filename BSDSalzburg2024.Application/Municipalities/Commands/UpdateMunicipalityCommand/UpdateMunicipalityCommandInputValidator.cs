﻿// <copyright file="UpdateMunicipalityCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.UpdateMunicipalityCommand;

using System.Linq;
using BSDSalzburg2024.Application.Models;
using BSDSalzburg2024.Application.Validation;
using FluentValidation;

public class UpdateMunicipalityCommandInputValidator
    : AbstractInputValidator<UpdateMunicipalityCommand>
{
    public UpdateMunicipalityCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.Country)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.Country)
            .Must(c => Country.GetFromIso(c) != null)
            .WithMessage("CountryInvalid");

        this.RuleFor(command => command.PostalCode)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.PostalCode)
            .Must(c => c.All(x => char.IsDigit(x)))
            .WithMessage("PostalCodeInvalidCharacter");

        this.RuleFor(command => command.PostalCode)
            .Length(command => Country.GetFromIso(command.Country)?.PostalCodeDigitCount ?? 4)
            .WithMessage("PostalCodeInvalidLength");

        this.RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Required");
    }
}
