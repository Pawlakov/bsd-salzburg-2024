// <copyright file="CreateMunicipalityCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using MediatR;

public record CreateMunicipalityCommand
    : IRequest<int>
{
    public CreateMunicipalityCommand()
    {
        this.Id = 0;
        this.Country = Requests.Models.Country.Austria.IsoCode;
        this.PostalCode = string.Empty;
        this.Name = string.Empty;
    }

    public int Id { get; set; }

    public string Country { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }
}