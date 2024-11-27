// <copyright file="UpdateLocationCommandInputValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.UpdateLocationCommand;

using System.Linq;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Application.Requests.Validation;
using FluentValidation;

public class UpdateLocationCommandInputValidator
    : AbstractInputValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandInputValidator()
    {
        this.RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.MunicipalityId)
            .NotEmpty()
            .WithMessage("Required");

        this.RuleFor(command => command.PostalCode)
            .NotEmpty()
            .WithMessage("Required")
            .Must(c => c.All(x => char.IsDigit(x)))
            .WithMessage("PostalCodeInvalidCharacter")
            .MinimumLength(4)
            .WithMessage("PostalCodeInvalidLength")
            .MaximumLength(5)
            .WithMessage("PostalCodeInvalidLength");

        this.RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Required")
            .MaximumLength(30)
            .WithMessage("NameTooLong");

        this.RuleFor(command => command.Address)
            .NotEmpty()
            .WithMessage("Required")
            .MaximumLength(50)
            .WithMessage("AddressTooLong");
    }
}
