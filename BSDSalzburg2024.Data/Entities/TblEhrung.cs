// <copyright file="TblEhrung.cs" company="Paweł Matusek">
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
public partial class TblEhrung
{
    public int SpenderId { get; set; }

    public string EhrungsId { get; set; }

    public DateTime? DatumGeschenk { get; set; }

    public bool? BesuchFeier { get; set; }

    public DateTime? DatumFeier { get; set; }

    public bool? FeierBesucht { get; set; }

    public string Anmerkung { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblEhrung> entity)
    {
        entity.HasKey(e => new { e.SpenderId, e.EhrungsId }).HasFillFactor(90);

        entity.ToTable("tblEhrung");

        entity.Property(e => e.EhrungsId)
            .HasMaxLength(8)
            .IsUnicode(false);
        entity.Property(e => e.Anmerkung)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.DatumFeier).HasColumnType("smalldatetime");
        entity.Property(e => e.DatumGeschenk).HasColumnType("smalldatetime");
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member