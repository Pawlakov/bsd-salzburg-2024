// <copyright file="MunicipalityConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class MunicipalityConfiguration
    : IEntityTypeConfiguration<Municipality>
{
    public void Configure(EntityTypeBuilder<Municipality> builder)
    {
        builder.HasKey(e => e.Id).HasFillFactor(90);

        builder.ToTable("tblGemeinde");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("GemeindeID");
        builder.Property(e => e.Country)
            .IsRequired()
            .HasMaxLength(3)
            .IsUnicode(false)
            .HasColumnName("GemeindeLand");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("GemeindeName");
        builder.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("GemeindePLZ");

        builder.HasMany(e => e.Locations)
            .WithOne(e => e.Municipality)
            .HasForeignKey(e => e.MunicipalityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}