// <copyright file="Program.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>
namespace BSDSalzburg2024.WebUI;

using System.Threading.Tasks;
using BSDSalzburg2024.Application.HostBuilders;
using BSDSalzburg2024.Data.HostBuilders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.AddRequests();
        builder.Services.AddValidation();
        builder.Host.AddDbContextLocal();

        builder.Services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();
        app.UseRequestLocalization("en-US");

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        await app.RunAsync();
    }
}