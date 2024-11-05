// <copyright file="Program.cs" company="Pawe³ Matusek">
// Copyright (c) Pawe³ Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.WebUI;

using BSDSalzburg2024.Application.HostBuilders;
using BSDSalzburg2024.Data.HostBuilders;
using BSDSalzburg2024.WebUI.Components;
using BSDSalzburg2024.WebUI.Components.Account;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies();

        builder.Services.AddControllers();
        builder.Services.AddRequests();
        builder.Services.AddValidation();
        builder.Host.AddDbContextLocal(identityBuilder => identityBuilder.AddSignInManager().AddDefaultTokenProviders());
        builder.Services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        var supportedCultures = new[] { "en-US", "de-AT" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[1])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);
        app.UseRequestLocalization(localizationOptions);
        app.MapControllers();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
