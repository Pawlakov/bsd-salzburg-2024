﻿// <copyright file="DeleteLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using MediatR;

public record DeleteLocationCommand
    : IRequest
{
    public DeleteLocationCommand(string id)
    {
        this.Id = id;
    }

    public string Id { get; }
}
