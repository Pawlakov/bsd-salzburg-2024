// <copyright file="GetDonationEventQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using Mediator;

public sealed record class GetDonationEventQuery() : IQuery<GetDonationEventQueryResult>;