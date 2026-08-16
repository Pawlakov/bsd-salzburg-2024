// <copyright file="GetLocationQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Locations;

public class GetLocationQueryResultItem
{
    required public string Id { get; set; }

    required public int MunicipalityId { get; set; }

    required public string Name { get; set; }

    required public string PostalCode { get; set; }

    required public string Address { get; set; }

    required public bool Hidden { get; set; }
}