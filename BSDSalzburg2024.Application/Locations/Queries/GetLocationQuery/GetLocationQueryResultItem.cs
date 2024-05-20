// <copyright file="GetLocationQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Locations.Queries.GetLocationQuery;

public record GetLocationQueryResultItem(string Id, int MunicipalityId, string Name, string PostalCode, string Address, bool Hidden);