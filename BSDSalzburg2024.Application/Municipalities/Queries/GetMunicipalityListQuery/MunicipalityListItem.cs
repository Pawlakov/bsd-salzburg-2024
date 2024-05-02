// <copyright file="MunicipalityListItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using BSDSalzburg2024.Application.Models;

public record MunicipalityListItem(int Index, int Id, Country Country, string PostalCode, string Name, bool CanBeDeleted);
