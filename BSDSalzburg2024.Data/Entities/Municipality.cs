// <copyright file="Municipality.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Municipality
{
    public int Id { get; set; }

    public string Country { get; set; }

    public string PostalCode { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Location> Locations { get; private set; }

    internal static void EntityBuildAction(EntityTypeBuilder<Municipality> entity)
    {
        entity.HasKey(e => e.Id).HasFillFactor(90);

        entity.ToTable("tblGemeinde");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("GemeindeID");
        entity.Property(e => e.Country)
            .IsRequired()
            .HasMaxLength(3)
            .IsUnicode(false)
            .HasColumnName("GemeindeLand");
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("GemeindeName");
        entity.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("GemeindePLZ");

        entity.HasMany(e => e.Locations)
            .WithOne(e => e.Municipality)
            .HasForeignKey(e => e.MunicipalityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
