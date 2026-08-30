// <copyright file="UpdateMunicipalityCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Linq;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Domain;
using BSDSalzburg2024.Domain.Entities;

using FluentValidation;

internal class UpdateMunicipalityCommandDataValidator
    : AbstractDataValidator<UpdateMunicipalityCommand>
{
    internal UpdateMunicipalityCommandDataValidator(IBaseRepository<Municipality, int> context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.AsQueryable().Any(x => x.Id == id))
            .WithMessage("IdInvalid");
    }
}