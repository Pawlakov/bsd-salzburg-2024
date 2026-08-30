// <copyright file="LocationConfiguration.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Infrastructure.Configurations;

using BSDSalzburg2024.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class LocationConfiguration
    : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(e => e.Id).HasFillFactor(90);

        builder.ToTable("tblOrt");

        builder.Property(e => e.Id)
            .HasMaxLength(8)
            .IsUnicode(false)
            .HasColumnName("OrtID");
        builder.Property(e => e.MunicipalityId)
            .HasColumnName("GemeindeID");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(30)
            .IsUnicode(false)
            .HasColumnName("OrtName");
        builder.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .HasColumnName("OrtPlz");
        builder.Property(e => e.Address)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("OrtStrasse");
        builder.Property(e => e.Hidden)
            .HasColumnName("Unsichtbar");

        builder.HasMany(e => e.DonationEvents)
            .WithOne(e => e.Location)
            .HasForeignKey(e => e.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}