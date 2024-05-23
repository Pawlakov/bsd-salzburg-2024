// <copyright file="ListQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Base.Queries.ListQuery;

using System.Collections.Generic;

public record ListQueryResult<TListQueryResultItem, TId>
    where TListQueryResultItem : IListQueryResultItem<TId>
{
    public IReadOnlyCollection<TListQueryResultItem> Items { get; init; }

    public int ItemsTotal { get; init; }
}