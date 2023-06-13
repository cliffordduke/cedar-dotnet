using System.Text.Json.Serialization;

namespace CedarDotNet.Models;

public class AuthorizationQuery
{
    [JsonPropertyName("principal")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Principal { get; init; }
    public string Action { get; init; }
    public string? Resource { get; init; }
    public string? Context { get; set; }
    public Slice Slice { get; set; }
    
}