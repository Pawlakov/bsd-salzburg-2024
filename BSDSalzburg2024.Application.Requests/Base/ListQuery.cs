// <copyright file="ListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Base;

using Mediator;

public sealed record class ListQuery<TListQueryResultItem, TId>
    : IQuery<ListQueryResult<TListQueryResultItem, TId>>
    where TListQueryResultItem : IListQueryResultItem<TId>
{
    public ListQuery(int pageIndex, int pageSize)
    {
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
    }

    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}