// <copyright file="CreateLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Commands.CreateLocationCommand;

using MediatR;

public record CreateLocationCommand
    : IRequest<string>
{
    public CreateLocationCommand()
    {
        this.Id = string.Empty;
    }

    public string Id { get; set; }
}
