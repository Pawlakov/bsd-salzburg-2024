// <copyright file="TblMitarbeiterSpendeaktion.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
