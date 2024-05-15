// <copyright file="DeleteLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.DeleteLocationCommand;

using MediatR;

public record DeleteLocationCommand
    : IRequest
{
    public DeleteLocationCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; }
}
