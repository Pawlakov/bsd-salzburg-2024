// <copyright file="Program.cs" company="Pawe³ Matusek">
// Copyright (c) Pawe³ Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.WebUI;

using BSDSalzburg2024.Application.HostBuilders;
using BSDSalzburg2024.Data.HostBuilders;
using BSDSalzburg2024.WebUI.Components;
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
        app.UseRequestLocalization("en-US");

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
