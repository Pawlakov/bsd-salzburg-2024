// <copyright file="TblPostleitzahl.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
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
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
