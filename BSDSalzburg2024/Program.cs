// <copyright file="Program.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024;

using System;
using BSDSalzburg2024.Application.HostBuilders;
using BSDSalzburg2024.Application.Requests.HostBuilders;
using BSDSalzburg2024.Auth;
using BSDSalzburg2024.Auth.Extensions;
using BSDSalzburg2024.Components;
using BSDSalzburg2024.Data.HostBuilders;

using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddScoped<ProtectedLocalStorage>();

        builder.Services.AddAuthentication().AddScheme<DummyAuthSchemeOptions, DummyAuthSchemeHandler>("MyAuth", options => {});
        builder.Services.AddAuthorizationCore();

        builder.Services.AddScoped<MyAuthenticationStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<MyAuthenticationStateProvider>());

        builder.Services.AddOriginalCascadingAuthenticationState();
        builder.Services.AddMyCascadingAuthenticationState();

        builder.Services.AddRequests();
        builder.Services.AddDataValidation();
        builder.Services.AddInputValidation();
        builder.Host.AddDbContextLocal();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
