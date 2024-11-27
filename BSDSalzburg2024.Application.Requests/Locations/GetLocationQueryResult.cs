// <copyright file="GetLocationQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

public record GetLocationQueryResult
{
    public GetLocationQueryResultItem? Item { get; init; }
}
