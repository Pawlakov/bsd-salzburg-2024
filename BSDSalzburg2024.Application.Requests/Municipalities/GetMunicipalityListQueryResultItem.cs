// <copyright file="GetMunicipalityListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Application.Requests.Models;

public record GetMunicipalityListQueryResultItem(int Index, int Id, Country Country, string PostalCode, string Name, bool CanBeDeleted) : IListQueryResultItem<int>;
