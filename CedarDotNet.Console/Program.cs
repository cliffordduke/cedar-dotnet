

using CedarDotNet;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

var test = File.ReadAllText("test.json");
var options = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};
options.Converters.Add(new JsonStringEnumConverter());
Console.WriteLine(JsonSerializer.Serialize(Cedar.NativeIsAuthorized(test), options));