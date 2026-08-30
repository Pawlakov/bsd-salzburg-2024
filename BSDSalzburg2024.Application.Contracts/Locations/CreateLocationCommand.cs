// <copyright file="CreateLocationCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using Mediator;

public sealed record class CreateLocationCommand : ICommand<string>
{
    public CreateLocationCommand(string id, int municipalityId, string postalCode, string name, string address, bool hidden)
    {
        this.Id = id;
        this.MunicipalityId = municipalityId;
        this.PostalCode = postalCode;
        this.Name = name;
        this.Address = address;
        this.Hidden = hidden;
    }

    public string Id { get; set; }

    public int MunicipalityId { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public bool Hidden { get; set; }
}