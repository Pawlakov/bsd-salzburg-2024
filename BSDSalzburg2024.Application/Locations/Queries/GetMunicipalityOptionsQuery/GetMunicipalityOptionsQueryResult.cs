// <copyright file="GetMunicipalityOptionsQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetMunicipalityOptionsQuery;

using System.Collections.Generic;

public record GetMunicipalityOptionsQueryResult
{
    public IReadOnlyCollection<GetMunicipalityOptionsQueryResultItem> Items { get; init; }
}
