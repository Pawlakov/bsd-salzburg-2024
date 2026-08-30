// <copyright file="SexJsonConverter.cs" company="Paweł Matusek">
// Copyright (c) Paweł Matusek. All rights reserved.
// </copyright>

namespace BSDSalzburg2024.Application.Requests.Models;

using System;

using Newtonsoft.Json;

public class SexJsonConverter
    : JsonConverter<Sex>
{
    public override Sex? ReadJson(JsonReader reader, Type objectType, Sex? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType != JsonToken.String)
        {
            throw new JsonException();
        }

        var character = reader.Value.ToString();
        return Sex.GetFromChar(character);
    }

    public override void WriteJson(JsonWriter writer, Sex? value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Character);
    }
}