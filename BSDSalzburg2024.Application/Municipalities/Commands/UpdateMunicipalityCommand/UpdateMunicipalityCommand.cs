// <copyright file="UpdateMunicipalityCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.UpdateMunicipalityCommand;

using MediatR;

public record UpdateMunicipalityCommand
    : IRequest
{
    public UpdateMunicipalityCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; }

    public string Country { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }
}
