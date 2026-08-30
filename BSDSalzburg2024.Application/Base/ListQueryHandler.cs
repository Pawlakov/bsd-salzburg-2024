// <copyright file="ListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Base;

using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Requests.Base;
using BSDSalzburg2024.Domain.Entities;

using Mediator;

public abstract class ListQueryHandler<TListQueryResultItem, TId, TEntity>
    : IQueryHandler<ListQuery<TListQueryResultItem, TId>, ListQueryResult<TListQueryResultItem, TId>>
    where TListQueryResultItem : IListQueryResultItem<TId>
    where TEntity : class, IKeyedEntity<TId>
{
    private readonly IBaseRepository<TEntity, TId> context;

    public ListQueryHandler(IBaseRepository<TEntity, TId> context)
    {
        this.context = context;
    }

    protected IBaseRepository<TEntity, TId> Context => this.context;

    public abstract ValueTask<ListQueryResult<TListQueryResultItem, TId>> Handle(ListQuery<TListQueryResultItem, TId> request, CancellationToken cancellationToken);
}