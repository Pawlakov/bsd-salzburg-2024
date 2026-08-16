// <copyright file="ListQueryResult.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Base;

using System.Collections.Generic;

public class ListQueryResult<TListQueryResultItem, TId>
    where TListQueryResultItem : IListQueryResultItem<TId>
{
    required public IReadOnlyCollection<TListQueryResultItem> Items { get; init; }

    required public int ItemsTotal { get; init; }
}