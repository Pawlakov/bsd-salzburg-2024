// <copyright file="CreateLocationCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.CreateLocationCommand;

using System.Linq;
using BSDSalzburg2024.Application.Models;
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

        this.RuleFor(command => command.MunicipalityId)
            .Must(id => context.Municipalities.Where(x => x.Id == id).Any())
            .WithMessage("MunicipalityIdInvalid");

        this.RuleFor(command => command.PostalCode)
            .Length(command => Country.GetFromIso(context.Municipalities.Where(x => x.Id == command.MunicipalityId).FirstOrDefault()?.Country)?.PostalCodeDigitCount ?? 4)
            .WithMessage("PostalCodeInvalidLength");
    }
}
