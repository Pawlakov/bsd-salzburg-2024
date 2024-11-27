// <copyright file="GetMunicipalityOptionsQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using System.Collections.Generic;

public record GetMunicipalityOptionsQueryResult
{
    public required IReadOnlyCollection<GetMunicipalityOptionsQueryResultItem> Items { get; init; }
}
