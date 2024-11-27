// <copyright file="DeleteDonationEventCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using MediatR;

public class DeleteDonationEventCommand
    : IRequest
{
    public DeleteDonationEventCommand(int id)
    {
        this.Id = id;
    }

    public int Id { get; }
}