using System.Text.Json;

namespace Exterminator.Models;

public class ExceptionModel
{
    public int StatusCode { get; set; }
    public string ExceptionMessage { get; set; }
    public string StackTrace { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}