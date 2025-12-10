// <copyright file="CountryJsonConverter.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Models;

using System;

using Newtonsoft.Json;

public class CountryJsonConverter
    : JsonConverter<Country>
{
    public override Country? ReadJson(JsonReader reader, Type objectType, Country? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType != JsonToken.String)
        {
            throw new JsonException();
        }

        var isoCode = reader.Value.ToString();
        return Country.GetFromIso(isoCode);
    }

    public override void WriteJson(JsonWriter writer, Country? value, JsonSerializer serializer)
    {
        writer.WriteValue(value.IsoCode);
    }
}
