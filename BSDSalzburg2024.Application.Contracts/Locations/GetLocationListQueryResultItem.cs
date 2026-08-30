// <copyright file="GetLocationListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using BSDSalzburg2024.Application.Requests.Base;

public class GetLocationListQueryResultItem
    : IListQueryResultItem<string>
{
    required public int Index { get; set; }

    required public string Id { get; set; }

    required public string Name { get; set; }

    required public string PostalCode { get; set; }

    required public string Address { get; set; }

    required public string Municipality { get; set; }

    required public bool Hidden { get; set; }

    required public bool CanBeDeleted { get; set; }
}