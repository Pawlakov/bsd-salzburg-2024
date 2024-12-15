// <copyright file="Program.cs" company="Pawe³ Matusek">
// Copyright (c) Pawe³ Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.WebUI;

using System;
using BSDSalzburg2024.Application.HostBuilders;
using BSDSalzburg2024.Data.HostBuilders;
using BSDSalzburg2024.WebUI.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
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
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(48);
                options.SlidingExpiration = true;
            });

        builder.Services.AddControllers();
        builder.Services.AddRequests();
        builder.Services.AddValidation();
        builder.Host.AddDbContextLocal();
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

        app.UseAuthentication();
        app.UseAuthorization();

        var supportedCultures = new[] { "en-US", "de-AT" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture(supportedCultures[1])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);
        app.UseRequestLocalization(localizationOptions);
        app.MapControllers();

        app.MapRazorComponents<App>()
            .AddAdditionalAssemblies(typeof(Components.Pages.Municipalities.List).Assembly)
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
