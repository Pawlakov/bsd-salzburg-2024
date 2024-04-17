// <copyright file="TblOrt.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class TblOrt
{
    public string OrtId { get; set; }

    public int? GemeindeId { get; set; }

    public string OrtLand { get; set; }

    public string OrtPlz { get; set; }

    public string OrtName { get; set; }

    public string OrtStrasse { get; set; }

    public bool Unsichtbar { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblOrt> entity)
    {
        entity.HasKey(e => e.OrtId).HasFillFactor(90);

        entity.ToTable("tblOrt");

        entity.Property(e => e.OrtId)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("OrtID");
        entity.Property(e => e.GemeindeId).HasColumnName("GemeindeID");
        entity.Property(e => e.OrtLand)
            .HasMaxLength(3)
            .IsUnicode(false);
        entity.Property(e => e.OrtName)
            .HasMaxLength(30)
            .IsUnicode(false);
        entity.Property(e => e.OrtPlz)
            .HasMaxLength(5)
            .IsUnicode(false);
        entity.Property(e => e.OrtStrasse)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
