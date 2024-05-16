// <copyright file="UpdateLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.UpdateLocationCommand;

using MediatR;

public record UpdateLocationCommand
    : IRequest
{
    public UpdateLocationCommand(string id)
    {
        this.Id = id;
    }

    public string Id { get; }
}
