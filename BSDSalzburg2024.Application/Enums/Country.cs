// <copyright file="Country.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Enums;

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