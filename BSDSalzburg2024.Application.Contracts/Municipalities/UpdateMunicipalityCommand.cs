// <copyright file="UpdateMunicipalityCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using Mediator;

public record class UpdateMunicipalityCommand
    : ICommand
{
    public UpdateMunicipalityCommand(int id, string? country, string? postalCode, string? name)
    {
        this.Id = id;
        this.Country = country;
        this.PostalCode = postalCode;
        this.Name = name;
    }

    public int Id { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public string? Name { get; set; }
}