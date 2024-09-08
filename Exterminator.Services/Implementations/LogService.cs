using System.Collections.Generic;
using Exterminator.Models;
using Exterminator.Models.Dtos;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Interfaces;

namespace Exterminator.Services.Implementations;

public class LogService(ILogRepository logRepository) : ILogService
{
    public void LogToDatabase(ExceptionModel exception)
    {
        logRepository.LogToDatabase(exception);
    }
    // TODO: Should contain a method which retrieves all logs (LogDto) ordered by timestamp (descending)
    public IEnumerable<LogDto> GetAllLogs() => logRepository.GetAllLogs();
}