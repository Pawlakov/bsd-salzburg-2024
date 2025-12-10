namespace BSDSalzburg2024.Application.Requests.HostBuilders;

using System;
using System.Linq;
using System.Collections.Generic;

using BSDSalzburg2024.Application.Requests.Municipalities;
using BSDSalzburg2024.Application.Requests.Validation;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

public static class WebUIHostBuilderExtensions
{
    public static IServiceCollection AddInputValidation(this IServiceCollection services)
    {
        var inputValidatorInterfaceType = typeof(IInputValidator<>);
        var list = inputValidatorInterfaceType.Assembly.GetTypes()
                .Where(mytype => mytype.GetInterface(inputValidatorInterfaceType.Name) != null && !mytype.IsInterface && !mytype.IsAbstract)
                .ToList();

        foreach (var item in list)
        {
            var interfaceType = item.GetInterface(inputValidatorInterfaceType.Name);

            services.TryAddEnumerable(new ServiceDescriptor(interfaceType!, item, ServiceLifetime.Scoped));
            services.TryAdd(new ServiceDescriptor(item, item, ServiceLifetime.Scoped));
        }

        return services;
    }
}
