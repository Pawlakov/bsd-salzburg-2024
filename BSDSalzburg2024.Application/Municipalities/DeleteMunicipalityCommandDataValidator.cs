﻿// <copyright file="DeleteMunicipalityCommandDataValidator.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities;

using System.Linq;
using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Application.Validation;
using BSDSalzburg2024.Data;
using FluentValidation;

public class DeleteMunicipalityCommandDataValidator
    : AbstractDataValidator<DeleteMunicipalityCommand>
{
    public DeleteMunicipalityCommandDataValidator(BsdDatabaseContext context)
    {
        this.RuleFor(command => command.Id)
            .Must(id => context.Municipalities.Where(x => x.Id == id).Any())
            .WithMessage("IdInvalid");

        this.RuleFor(command => command.Id)
            .Must(id => !context.Locations.Where(x => x.MunicipalityId == id).Any())
            .WithMessage("IdDependentLocations");
    }
}