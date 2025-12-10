// <copyright file="Sex.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

[JsonConverter(typeof(SexJsonConverter))]
public class Sex
{
    private Sex(char character)
    {
        this.Character = character;
    }

    public char Character { get; init; }

    public static Sex Male { get; } = new Sex('M');

    public static Sex Female { get; } = new Sex('F');

    public static IReadOnlyCollection<Sex> Options => [Male, Female];

    public static Sex? GetFromChar(string? isoCode)
    {
        if (isoCode is null || isoCode.Length is not 1)
        {
            return null;
        }

        return isoCode.ToUpper() switch
        {
            "M" => Male,
            "F" => Female,
            _ => null,
        };
    }
}
