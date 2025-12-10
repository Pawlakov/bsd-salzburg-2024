namespace BSDSalzburg2024.WebUI.Client;

using System;
using System.Net.Http;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.HostBuilders;

using MediatR;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddScoped(serviceProvider => new HttpClient
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
        });

        builder.Services.AddScoped<IMediator, HttpMediator>();

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();

        builder.Services.AddInputValidation();

        var host = builder.Build();

        await host.RunAsync();
    }
}