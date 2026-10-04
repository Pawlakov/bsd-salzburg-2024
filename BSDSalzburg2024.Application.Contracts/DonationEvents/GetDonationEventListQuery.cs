// <copyright file="GetDonationEventListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using BSDSalzburg2024.Application.Requests.Base;

public record GetDonationEventListQuery() : ListQuery<GetDonationEventListQueryResultItem, int>;