// <copyright file="DeleteMunicipalityCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.DeleteMunicipalityCommand;

using MediatR;

public class DeleteMunicipalityCommand : IRequest
{
    public int Id { get; set; }
}