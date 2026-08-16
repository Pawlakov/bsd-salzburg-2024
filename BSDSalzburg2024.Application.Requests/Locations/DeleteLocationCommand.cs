// <copyright file="DeleteLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using Mediator;

public sealed record class DeleteLocationCommand(string Id) : ICommand;