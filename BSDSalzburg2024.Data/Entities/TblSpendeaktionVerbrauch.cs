// <copyright file="TblSpendeaktionVerbrauch.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblSpendeaktionVerbrauch
{
    public int SpendeaktionId { get; set; }

    public string Verbrauchsgut { get; set; }

    public int? Menge { get; set; }

    public string Kommentar { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblSpendeaktionVerbrauch> entity)
    {
        entity.HasKey(e => new { e.SpendeaktionId, e.Verbrauchsgut }).HasFillFactor(90);

        entity.ToTable("tblSpendeaktionVerbrauch");

        entity.Property(e => e.SpendeaktionId).HasColumnName("SpendeaktionID");
        entity.Property(e => e.Verbrauchsgut)
            .HasMaxLength(20)
            .IsUnicode(false);
        entity.Property(e => e.Kommentar)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
