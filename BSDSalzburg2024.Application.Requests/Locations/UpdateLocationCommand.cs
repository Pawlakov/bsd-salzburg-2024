// <copyright file="UpdateLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using MediatR;

public record UpdateLocationCommand
    : IRequest
{
    public UpdateLocationCommand(string id)
    {
        this.Id = id;
    }

    public string Id { get; }

    public int MunicipalityId { get; set; }

    public string? PostalCode { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public bool Hidden { get; set; }
}
