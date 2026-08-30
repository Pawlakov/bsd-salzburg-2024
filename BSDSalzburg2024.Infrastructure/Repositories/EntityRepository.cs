// <copyright file="EntityRepository.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Infrastructure.Repositories;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Application.Base;
using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public class EntityRepository<TEntity, TKey>
    : IBaseRepository<TEntity, TKey>
    where TEntity : class, IKeyedEntity<TKey>
{
    private readonly BsdDatabaseContext context;

    public EntityRepository(BsdDatabaseContext context)
    {
        this.context = context;
    }

    public IQueryable<TEntity> AsQueryable()
    {
        return this.context.Set<TEntity>();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await this.context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> FindAsync(TKey key, CancellationToken cancellationToken = default)
    {
        return await this.context.Set<TEntity>().FindAsync([key], cancellationToken: cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await this.context.Set<TEntity>().CountAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        this.context.Add(entity);
    }

    public void Update(TEntity entity)
    {
        this.context.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        this.context.Remove(entity);
    }
}