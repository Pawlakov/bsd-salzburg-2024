// <copyright file="GetMunicipalityQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityQuery;

using BSDSalzburg2024.Application.Models;

public record GetMunicipalityQueryResultItem(int Id, Country Country, string PostalCode, string Name);