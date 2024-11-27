// <copyright file="GetLocationListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

using BSDSalzburg2024.Application.Requests.Base;

public record GetLocationListQueryResultItem(int Index, string Id, string Name, string PostalCode, string Address, string Municipality, bool Hidden, bool CanBeDeleted) : IListQueryResultItem<string>;