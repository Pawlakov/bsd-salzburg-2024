// <copyright file="GetDonationEventListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.DonationEvents;

using BSDSalzburg2024.Application.Requests.Base;

public class GetDonationEventListQueryResultItem
    : IListQueryResultItem<int>
{
    required public int Index { get; set; }

    required public int Id { get; set; }

    required public bool CanBeDeleted { get; set; }
}