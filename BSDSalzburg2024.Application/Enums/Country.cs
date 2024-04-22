// <copyright file="Country.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Enums;

/// <summary>
/// Repensents a country following the ISO 3166 standard.
/// </summary>
public class Country
{
    private Country(string isoCode, string name, string flagEmoji)
    {
        this.IsoCode = isoCode;
        this.Name = name;
        this.FlagEmoji = flagEmoji;
    }

    public static Country Austria { get; } = new Country("AUT", "Austria", "🇦🇹");

    public static Country Germany { get; } = new Country("DEU", "Germany", "🇩🇪");

    public static Country Poland { get; } = new Country("POL", "Poland", "🇵🇱");

    public string IsoCode { get; init; }

    public string Name { get; init; }

    public string FlagEmoji { get; init; }

    public static Country GetFromIso(string isoCode)
    {
        switch (isoCode.ToUpper())
        {
            case "AUT":
                return Austria;
            case "DEU":
                return Germany;
            case "POL":
                return Poland;
            default:
                throw new Exception("Unknown country");
        }
    }
}