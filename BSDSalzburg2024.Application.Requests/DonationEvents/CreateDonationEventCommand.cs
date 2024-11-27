// <copyright file="CreateDonationEventCommand.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using MediatR;

public class CreateDonationEventCommand
    : IRequest<int>
{
    public CreateDonationEventCommand()
    {
        this.Id = 0;
    }

    public int Id { get; set; }
}