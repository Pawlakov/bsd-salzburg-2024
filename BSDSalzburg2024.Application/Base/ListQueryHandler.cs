// <copyright file="ListQueryHandler.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Base;

using BSDSalzburg2024.Domain.Entities;

public abstract class ListQueryHandler<TId, TEntity>
    where TEntity : class, IKeyedEntity<TId>
{
    private readonly IBaseRepository<TEntity, TId> context;

    public ListQueryHandler(IBaseRepository<TEntity, TId> context)
    {
        this.context = context;
    }

    protected IBaseRepository<TEntity, TId> Context => this.context;
}