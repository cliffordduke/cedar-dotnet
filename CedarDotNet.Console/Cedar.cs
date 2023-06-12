using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CedarDotNet.Console;

public class AuthorizationResult
{
    public bool Success { get; set; }
    public Result Result { get; set; }
    
}

public enum Decision
{
    Allow,
    Deny
}

public struct Result
{
    public Decision Decision { get; set; }
    public Diagnostics Diagnostics { get; set; }
}

public struct Diagnostics
{
    public string[] Reason { get; set; }
    public string[] Errors { get; set; }
}

public static class Cedar
{
    [DllImport("libCedarDotNetFFI")]
    public static extern string Validate(string source);
    
    [DllImport("libCedarDotNetFFI")]
    public static extern string IsAuthorized(string source);

    public static AuthorizationResult NativeIsAuthorized(string payload)
    {
        var result = IsAuthorized(payload);
        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Deserialize<AuthorizationResult>(result, options) ?? new AuthorizationResult {Success = false};
    }
    
}