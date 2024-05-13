// <copyright file="GetMunicipalityQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityQuery;

using System.Collections.Generic;

public record GetMunicipalityQueryResult
{
    public GetMunicipalityQueryResultItem? Item { get; init; }
}