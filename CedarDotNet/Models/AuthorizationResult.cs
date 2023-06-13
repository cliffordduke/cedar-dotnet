namespace CedarDotNet.Models;

public class AuthorizationResult
{
    public Decision Decision { get; init; }
    public Diagnostics Diagnostics { get; init; }

}

public enum Decision
{
    Allow,
    Deny,
    NoDecision
}


public struct Diagnostics
{
    public List<string> Reason { get; init; }
    public List<string> Errors { get; init; }
}