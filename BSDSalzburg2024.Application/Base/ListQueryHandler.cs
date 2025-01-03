﻿// <copyright file="ListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Base;

using System.Threading;
using System.Threading.Tasks;
using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Data;
using MediatR;

public abstract class ListQueryHandler<TListQueryResultItem, TId>
    : IRequestHandler<ListQuery<TListQueryResultItem, TId>, ListQueryResult<TListQueryResultItem, TId>>
    where TListQueryResultItem : IListQueryResultItem<TId>
{
    private readonly BsdDatabaseContext context;

    public ListQueryHandler(BsdDatabaseContext context)
    {
        this.context = context;
    }

    protected BsdDatabaseContext Context => this.context;

    public abstract Task<ListQueryResult<TListQueryResultItem, TId>> Handle(ListQuery<TListQueryResultItem, TId> request, CancellationToken cancellationToken);
}
