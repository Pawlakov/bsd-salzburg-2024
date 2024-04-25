// <copyright file="TblOrt.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class Location
{
    public string Id { get; set; }

    public int MunicipalityId { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public bool Hidden { get; set; }

    public virtual Municipality Municipality { get; set; }

    internal static void EntityBuildAction(EntityTypeBuilder<Location> entity)
    {
        entity.HasKey(e => e.Id).HasFillFactor(90);

        entity.ToTable("tblOrt");

        entity.Property(e => e.Id)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("OrtID");
        entity.Property(e => e.MunicipalityId)
            .HasColumnName("GemeindeID");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("OrtName");
        entity.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("OrtPlz");
        entity.Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("OrtStrasse");
        entity.Property(e => e.Hidden)
            .HasColumnName("Unsichtbar");
    }
}
