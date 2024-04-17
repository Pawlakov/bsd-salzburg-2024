// <copyright file="TblPostleitzahl.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblPostleitzahl
{
    public string Plz { get; set; }

    public string Land { get; set; }

    public string Ort { get; set; }

    public int? GemeindeId { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblPostleitzahl> entity)
    {
        entity.HasKey(e => e.Plz).HasFillFactor(90);

        entity.ToTable("tblPostleitzahl");

        entity.Property(e => e.Plz)
            .HasMaxLength(8)
            .IsUnicode(false);
        entity.Property(e => e.Land)
            .HasMaxLength(3)
            .IsUnicode(false);
        entity.Property(e => e.Ort)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
