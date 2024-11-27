// <copyright file="GetDonationEventListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using BSDSalzburg2024.Application.Requests.Base;

public record class GetDonationEventListQueryResultItem(int Index, int Id, bool CanBeDeleted) : IListQueryResultItem<int>;