using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CedarDotNet.Models;

namespace CedarDotNet;



public static class Cedar
{
    [DllImport("libCedarDotNetFFI")]
    private static extern string Validate(string source);
    
    [DllImport("libCedarDotNetFFI")]
    private static extern string IsAuthorized(string source);

    public static string NativeValidate(string payload)
    {
        var result = Validate(payload);
        return result;
    }
    public static AuthorizationResult NativeIsAuthorized(string payload)
    {
        var result = IsAuthorized(payload);
        Console.WriteLine(result);
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(),
                new BooleanConverter()
            }
        };
        var node = JsonNode.Parse(result);
        
        return JsonSerializer.Deserialize<AuthorizationResult>(node!["result"]?.ToString() ?? string.Empty, options) ??
               throw new Exception("Error serializing");
    }
    
}