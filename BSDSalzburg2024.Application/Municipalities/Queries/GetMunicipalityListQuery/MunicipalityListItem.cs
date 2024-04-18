// <copyright file="MunicipalityListItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Municipalities.Queries.GetMunicipalityListQuery;

using BSDSalzburg2024.Data.Entities;

public class MunicipalityListItem
{
    public MunicipalityListItem(Municipality entity)
    {
        this.Name = entity.Name;
    }

    public string Name { get; init; }
}