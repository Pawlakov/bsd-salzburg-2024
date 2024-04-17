// <copyright file="TblGemeinde.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblGemeinde
{
    public int GemeindeId { get; set; }

    public string GemeindeLand { get; set; }

    public string GemeindePlz { get; set; }

    public string GemeindeName { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblGemeinde> entity)
    {
        entity.HasKey(e => e.GemeindeId).HasFillFactor(90);

        entity.ToTable("tblGemeinde");

        entity.Property(e => e.GemeindeId)
            .ValueGeneratedNever()
            .HasColumnName("GemeindeID");
        entity.Property(e => e.GemeindeLand)
            .HasMaxLength(3)
            .IsUnicode(false);
        entity.Property(e => e.GemeindeName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.GemeindePlz)
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("GemeindePLZ");
    }
}
