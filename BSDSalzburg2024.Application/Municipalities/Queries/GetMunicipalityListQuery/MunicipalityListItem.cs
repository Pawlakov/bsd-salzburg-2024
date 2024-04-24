// <copyright file="MunicipalityListItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using BSDSalzburg2024.Application.Enums;

public class MunicipalityListItem
{
    public int Id { get; init; }

    public int Index { get; init; }

    public Country Country { get; init; }

    public string PostalCode { get; init; }

    public string Name { get; init; }
}