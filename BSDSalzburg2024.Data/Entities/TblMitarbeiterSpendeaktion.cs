// <copyright file="TblMitarbeiterSpendeaktion.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public partial class TblMitarbeiterSpendeaktion
{
    public int SpendeaktionId { get; set; }

    public string MitarbeiterId { get; set; }

    public string Funktion { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblMitarbeiterSpendeaktion> entity)
    {
        entity.HasKey(e => new { e.SpendeaktionId, e.MitarbeiterId }).HasFillFactor(90);

        entity.ToTable("tblMitarbeiterSpendeaktion");

        entity.Property(e => e.SpendeaktionId).HasColumnName("SpendeaktionID");
        entity.Property(e => e.MitarbeiterId)
            .HasMaxLength(12)
            .IsUnicode(false)
            .HasColumnName("MitarbeiterID");
        entity.Property(e => e.Funktion)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
