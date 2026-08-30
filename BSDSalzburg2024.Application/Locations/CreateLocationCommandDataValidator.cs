// <copyright file="CreateLocationCommandDataValidator.cs" company="Paweł Matusek">
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

internal class CreateLocationCommandDataValidator
    : AbstractDataValidator<CreateLocationCommand>
{
    internal CreateLocationCommandDataValidator(IBaseRepository<Location, string> context, IBaseRepository<Municipality, int> municipalitiesContext)
    {
        this.RuleFor(command => command.Id)
            .Must(id => !context.AsQueryable().Any(x => x.Id == id))
            .WithMessage("IdCollision");

        this.RuleFor(command => command.MunicipalityId)
            .Must(id => municipalitiesContext.AsQueryable().Any(x => x.Id == id))
            .WithMessage("MunicipalityIdInvalid");

        this.RuleFor(command => command.PostalCode)
            .Length(command => Country.GetFromIso(municipalitiesContext.AsQueryable().Where(x => x.Id == command.MunicipalityId).FirstOrDefault()?.Country)?.PostalCodeDigitCount ?? 4)
            .WithMessage("PostalCodeInvalidLength");
    }
}
