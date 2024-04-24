// <copyright file="UpdateMunicipalityCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Commands.UpdateMunicipalityCommand;

using MediatR;

public class UpdateMunicipalityCommand : IRequest
{
    public int Id { get; set; }
}