// <copyright file="GetMunicipalityQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using BSDSalzburg2024.Application.Requests.Models;

public class GetMunicipalityQueryResultItem
{
    required public int Id { get; set; }

    required public Country Country { get; set; }

    required public string PostalCode { get; set; }

    required public string Name { get; set; }
}