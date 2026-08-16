// <copyright file="TblLaborwert.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public class TblLaborwert
{
    public int LaborwertId { get; set; }

    public string LaborwertNameId { get; set; }

    public int? SpenderId { get; set; }

    public int? KonserveId { get; set; }

    public double? WertZahl { get; set; }

    public string WertText { get; set; }

    public DateTime? Datum { get; set; }

    public string Kommentar { get; set; }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member