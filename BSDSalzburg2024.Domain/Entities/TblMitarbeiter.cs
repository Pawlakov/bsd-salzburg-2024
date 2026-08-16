// <copyright file="TblMitarbeiter.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public class TblMitarbeiter
{
    public string MitarbeiterId { get; set; }

    public string Vorname { get; set; }

    public string Nachname { get; set; }

    public string Titel { get; set; }

    public DateTime? Geburtsdatum { get; set; }

    public string Geschlecht { get; set; }

    public string Funktion { get; set; }

    public string Land { get; set; }

    public string Plz { get; set; }

    public string Ort { get; set; }

    public string Straße { get; set; }

    public string TelBeruf { get; set; }

    public string TelHandy { get; set; }

    public string TelPrivat { get; set; }

    public string Email { get; set; }

    public int? GemeindeId { get; set; }

    public string Bagwinid { get; set; }

    public bool Aktiv { get; set; }

    public bool AusAltdaten { get; set; }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
