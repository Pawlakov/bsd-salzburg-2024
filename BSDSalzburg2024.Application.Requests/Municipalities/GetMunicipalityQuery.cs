// <copyright file="GetMunicipalityQuery.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Municipalities;

using MediatR;

public record GetMunicipalityQuery
    : IRequest<GetMunicipalityQueryResult>
{
    public GetMunicipalityQuery(int id)
    {
        this.Id = id;
    }

    public int Id { get; set; }
}
