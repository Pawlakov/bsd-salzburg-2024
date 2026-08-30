// <copyright file="IBaseRepository.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Base;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using BSDSalzburg2024.Domain.Entities;

public interface IBaseRepository<TEntity, in TKey>
    where TEntity : class, IKeyedEntity<TKey>
{
    IQueryable<TEntity> AsQueryable();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<TEntity?> FindAsync(TKey key, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    void Add(TEntity entity);

    void Update(TEntity entity);

    void Remove(TEntity entity);
}