namespace BSDSalzburg2024.WebUI.Client;

using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();

        builder.Services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });

        var host = builder.Build();

        await host.RunAsync();
    }
}