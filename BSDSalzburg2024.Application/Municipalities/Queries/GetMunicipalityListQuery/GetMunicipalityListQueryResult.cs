// <copyright file="GetMunicipalityListQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using System.Collections.Generic;

public record GetMunicipalityListQueryResult
{
    public IReadOnlyCollection<GetMunicipalityListQueryResultItem> Items { get; init; }

    public int ItemsTotal { get; init; }
}