using System;

namespace Exterminator.Models.Entities;

public class Log
{
    public int Id { get; init; }
    public string ExceptionMessage { get; init; }
    public string StackTrace { get; init; }
    public DateTime Timestamp { get; init; }
}