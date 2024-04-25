// <copyright file="TblLaborwert.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public partial class TblLaborwert
{
    public int LaborwertId { get; set; }

    public string LaborwertNameId { get; set; }

    public int? SpenderId { get; set; }

    public int? KonserveId { get; set; }

    public double? WertZahl { get; set; }

    public string WertText { get; set; }

    public DateTime? Datum { get; set; }

    public string Kommentar { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblLaborwert> entity)
    {
        entity.HasKey(e => e.LaborwertId).HasFillFactor(90);

        entity.ToTable("tblLaborwert");

        entity.Property(e => e.LaborwertId).HasColumnName("LaborwertID");
        entity.Property(e => e.Datum).HasColumnType("smalldatetime");
        entity.Property(e => e.Kommentar)
            .HasMaxLength(512)
            .IsUnicode(false);
        entity.Property(e => e.KonserveId).HasColumnName("KonserveID");
        entity.Property(e => e.LaborwertNameId)
            .HasMaxLength(16)
            .IsUnicode(false);
        entity.Property(e => e.WertText)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member