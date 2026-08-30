// <copyright file="GetMunicipalityQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

public class GetMunicipalityQueryResult
{
    required public GetMunicipalityQueryResultItem? Item { get; init; }
}