// <copyright file="Country.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Enums;

using System;
using System.Linq;

/// <summary>
/// Repensents a country following the ISO 3166 standard.
/// </summary>
public class Country
{
    private string postalCodeTemplate;

    private Country(string isoCode, string flagEmoji, string postalCodeTemplate)
    {
        this.IsoCode = isoCode;
        this.FlagEmoji = flagEmoji;
        this.postalCodeTemplate = postalCodeTemplate;
    }

    public static Country Austria { get; } = new Country("AUT", "🇦🇹", "XXXX");

    public static Country Germany { get; } = new Country("DEU", "🇩🇪", "XXXXX");

    public static Country Poland { get; } = new Country("POL", "🇵🇱", "XX-XXX");

    public string IsoCode { get; init; }

    public string FlagEmoji { get; init; }

    /// <summary>
    /// Reurns a <cref>Country</cref> corresponding to a ISO 3166 code.
    /// </summary>
    /// <param name="isoCode">3-character ISO 3166 country code. Case insensitive.</param>
    /// <returns>A <cref>Country</cref> corresponding to the given ISO 3166 code. Null if no <cref>Country</cref> found.</returns>
    public static Country GetFromIso(string isoCode)
    {
        if (isoCode is null)
        {
            return null;
        }

        return isoCode.ToUpper() switch
        {
            "AUT" => Austria,
            "DEU" => Germany,
            "POL" => Poland,
            _ => null,
        };
    }

    public string FormatPostalCode(string rawCode)
    {
        var characterIndex = 4;
        var charString = Enumerable.Empty<char>();
        foreach (var character in this.postalCodeTemplate.Reverse())
        {
            if (character == 'X')
            {
                charString = charString.Prepend(rawCode[characterIndex]);
                characterIndex -= 1;
            }
            else
            {
                charString = charString.Prepend(character);
            }
        }

        return new string(charString.ToArray());
    }
}