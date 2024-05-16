// <copyright file="GetLocationListQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationListQuery;

using System.Collections.Generic;

public record GetLocationListQueryResult
{
    public IReadOnlyCollection<GetLocationListQueryResultItem> Items { get; init; }

    public int ItemsTotal { get; init; }
}
