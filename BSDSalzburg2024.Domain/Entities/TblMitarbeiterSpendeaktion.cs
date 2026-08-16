// <copyright file="TblMitarbeiterSpendeaktion.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public class TblMitarbeiterSpendeaktion
{
    public int SpendeaktionId { get; set; }

    public string MitarbeiterId { get; set; }

    public string Funktion { get; set; }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
