// <copyright file="IListQueryResultItem.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Base;

public interface IListQueryResultItem<TId>
{
    int Index { get; }

    TId Id { get; }

    bool CanBeDeleted { get; }
}