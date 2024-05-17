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
        this.PostalCode = string.Empty;
        this.Name = string.Empty;
        this.Address = string.Empty;
    }

    public string Id { get; set; }

    public int MunicipalityId { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public bool Hidden { get; set; }
}
