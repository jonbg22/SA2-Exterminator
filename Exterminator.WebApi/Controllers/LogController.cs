using Exterminator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exterminator.WebApi.Controllers;

[Route("api/logs")]
public class LogController(ILogService logService) : Controller
{
    // TODO: Implement route which gets all logs from the ILogService, which should be injected through the constructor
    [HttpGet]
    public IActionResult GetAllLogs() => Ok(logService.GetAllLogs());
}