// <copyright file="DeleteDonationEventCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using Mediator;

public class DeleteDonationEventCommand
    : ICommand
{
    public DeleteDonationEventCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
}