// <copyright file="HostBuilderExtensions.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.HostBuilders;

using BSDSalzburg2024.Application.Municipalities;
using BSDSalzburg2024.Application.Validation;

using FluentValidation;

using Mediator;

using Microsoft.Extensions.DependencyInjection;

public static class HostBuilderExtensions
{
    public static IServiceCollection AddDataValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateMunicipalityCommandDataValidator).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}