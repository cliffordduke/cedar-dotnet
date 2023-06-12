

using CedarDotNet.Console;
using System.IO;
using System.Text.Json;

var test = File.ReadAllText("test.json"); 

Console.WriteLine(Cedar.IsAuthorized(test));
Console.WriteLine(JsonSerializer.Serialize(Cedar.NativeIsAuthorized(test)));