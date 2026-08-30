// <copyright file="IBaseKeyedEntity.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

public interface IKeyedEntity<TKey>
{
    TKey Id { get; set; }
}