// <copyright file="CreateDonationEventCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using Mediator;

public sealed record class CreateDonationEventCommand
    : ICommand
{
    public CreateDonationEventCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
}