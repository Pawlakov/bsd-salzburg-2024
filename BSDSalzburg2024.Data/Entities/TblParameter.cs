// <copyright file="TblParameter.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public partial class TblParameter
{
    public string ParameterTyp { get; set; }

    public string ParameterId { get; set; }

    public string ParameterWert { get; set; }

    public string Kommentar { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<TblParameter> entity)
    {
        entity.HasKey(e => new { e.ParameterTyp, e.ParameterId }).HasFillFactor(90);

        entity.ToTable("tblParameter");

        entity.Property(e => e.ParameterTyp)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.ParameterId)
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("ParameterID");
        entity.Property(e => e.Kommentar)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.ParameterWert)
            .HasMaxLength(50)
            .IsUnicode(false);
    }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
