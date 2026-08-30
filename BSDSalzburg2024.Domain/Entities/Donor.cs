// <copyright file="Donor.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System;

/// <summary>
/// DB entity representing a donor.
/// </summary>
public class Donor
    : IKeyedEntity<int>
{
    /// <summary>
    /// Gets or sets the ID of the donor.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the family name (last name) of the donor. Up to 40 characters.
    /// </summary>
    public string? FamilyName { get; set; }

    /// <summary>
    /// Gets or sets the given name (first name) of the donor. Up to 40 characters.
    /// </summary>
    public string? GivenName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Sex { get; set; }

    public string Titel { get; set; }

    public int? GemeindeId { get; set; }

    public string Strasse { get; set; }

    public string Land { get; set; }

    public string Plz { get; set; }

    public string Ort { get; set; }

    public string TelPrivat { get; set; }

    public string TelBeruf { get; set; }

    public string TelHandy { get; set; }

    public string Email { get; set; }

    public short? SpendenAnzahl { get; set; }

    public DateTime? SpendenLetzte { get; set; }

    public string Blutgruppe { get; set; }

    public string Phaenotyp { get; set; }

    public bool AusweisNoetig { get; set; }

    public DateTime? AusweisLetzter { get; set; }

    public bool EinladungBrief { get; set; }

    public bool EinladungEmail { get; set; }

    public bool EinladungSms { get; set; }

    public bool EinladungNurSms { get; set; }

    public bool EinladungKeine { get; set; }

    public string Kommentar { get; set; }

    public string KompanieFirma { get; set; }

    public string Status { get; set; }

    public bool ExpZentrale { get; set; }

    public DateTime? ExpZentraleDatum { get; set; }

    public string AenderungMitarbeiterId { get; set; }

    public DateTime? AenderungDatum { get; set; }

    public string AenderungTyp { get; set; }

    public string AenderungOrt { get; set; }

    public int? AenderungSpendeaktionId { get; set; }

    public int? ProgesaId { get; set; }
}