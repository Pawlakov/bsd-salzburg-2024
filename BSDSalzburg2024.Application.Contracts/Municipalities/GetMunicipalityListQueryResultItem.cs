// <copyright file="GetMunicipalityListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Application.Requests.Models;

public class GetMunicipalityListQueryResultItem
    : IListQueryResultItem<int>
{
    required public int Index { get; set; }

    required public int Id { get; set; }

    required public Country Country { get; set; }

    required public string PostalCode { get; set; }

    required public string Name { get; set; }

    required public bool CanBeDeleted { get; set; }
}