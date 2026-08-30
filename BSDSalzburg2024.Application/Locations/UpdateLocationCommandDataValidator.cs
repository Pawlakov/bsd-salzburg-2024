// <copyright file="UpdateLocationCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations;

using System.Linq;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Locations;
using BSDSalzburg2024.Application.Requests.Models;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Domain;
using BSDSalzburg2024.Domain.Entities;

using FluentValidation;

internal class UpdateLocationCommandDataValidator
    : AbstractDataValidator<UpdateLocationCommand>
{
    internal UpdateLocationCommandDataValidator(IBaseRepository<Location, string> context, IBaseRepository<Municipality, int> municipalityContext)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.AsQueryable().Any(x => x.Id == id))
            .WithMessage("IdInvalid");

        this.RuleFor(command => command.MunicipalityId)
            .Must(id => municipalityContext.AsQueryable().Any(x => x.Id == id))
            .WithMessage("MunicipalityIdInvalid");

        this.RuleFor(command => command.PostalCode)
            .Length(command => Country.GetFromIso(municipalityContext.AsQueryable().Where(x => x.Id == command.MunicipalityId).FirstOrDefault()?.Country)?.PostalCodeDigitCount ?? 4)
            .WithMessage("PostalCodeInvalidLength");
    }
}