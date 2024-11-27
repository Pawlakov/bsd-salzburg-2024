// <copyright file="ListQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Base;

using MediatR;

public record ListQuery<TListQueryResultItem, TId>
    : IRequest<ListQueryResult<TListQueryResultItem, TId>>
    where TListQueryResultItem : IListQueryResultItem<TId>
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}