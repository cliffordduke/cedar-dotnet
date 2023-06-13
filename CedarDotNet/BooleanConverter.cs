using System.Text.Json;
using System.Text.Json.Serialization;

namespace CedarDotNet;

public class BooleanConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.String => reader.GetString() switch
            {
                "true" => true,
                "yes" => true,
                "false" => false,
                "no" => false,
                _ => throw new JsonException("Cannot map boolean")
            },
            _ => throw new JsonException("Cannot map boolean")
        };
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
    }
}