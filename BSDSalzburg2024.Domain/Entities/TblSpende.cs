// <copyright file="TblSpende.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Domain.Entities;

using System;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1601 // Partial elements should be documented
public class TblSpende
{
    public int SpendeId { get; set; }

    public int? SpendeaktionId { get; set; }

    public int? SpenderId { get; set; }

    public string SpendeArt { get; set; }

    /// <summary>
    /// Gets or sets KonserveID 7-stellig.
    /// </summary>
    public int? KonserveId { get; set; }

    /// <summary>
    /// Gets or sets KonserveID 16-stellig.
    /// </summary>
    public string KonserveId2 { get; set; }

    public string AbnehmerId { get; set; }

    public string AnamneseId { get; set; }

    public string Selbstausschluss { get; set; }

    public DateTime? Datum { get; set; }

    public DateTime? AnamneseZeit { get; set; }

    public DateTime? Beginnzeit { get; set; }

    public DateTime? Endzeit { get; set; }

    public int? Menge { get; set; }

    public string BeutelAnz { get; set; }

    public string BeutelProdCode { get; set; }

    public short? BlutdruckSys { get; set; }

    public short? BlutdruckDia { get; set; }

    public float? Hb { get; set; }

    public float? Temperatur { get; set; }

    public short? Gewicht { get; set; }

    public int? AbgewId { get; set; }

    public string AbgewGrundId { get; set; }

    public string AbgewText { get; set; }

    public DateTime? AbgewSpHinBis { get; set; }

    public bool AbgewSpHinDauerhaft { get; set; }

    public DateTime? AscheinZeit { get; set; }

    public bool AscheinUngueltig { get; set; }

    public string AscheinKommentar { get; set; }

    public bool NichtLegitimiert { get; set; }

    public bool LabWertProvisorisch { get; set; }

    public bool ExpBlutbank { get; set; }

    public DateTime? ExpBlutbankDatum { get; set; }

    public bool ExpZentrale { get; set; }

    public DateTime? ExpZentraleDatum { get; set; }

    public string AenderungMitarbeiterId { get; set; }

    public DateTime? AenderungDatum { get; set; }

    public string AenderungTyp { get; set; }

    public string AenderungOrt { get; set; }

    public int? AenderungSpendeaktionId { get; set; }
}
#pragma warning restore SA1601 // Partial elements should be documented
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
