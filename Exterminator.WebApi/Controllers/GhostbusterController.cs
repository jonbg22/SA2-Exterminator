using Exterminator.Models.Exceptions;
using Exterminator.Models.InputModels;
using Exterminator.Services.Interfaces;
using Exterminator.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Exterminator.WebApi.Controllers;

[Route("api/ghostbusters")]
public class GhostbusterController(IGhostbusterService ghostbusterService) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IActionResult GetAllGhostbusters(string expertize = "") => Ok(ghostbusterService.GetAllGhostbusters(expertize));

    [HttpGet]
    [Route("{id:int}", Name = "GetGhostbusterById")]
    public IActionResult GetGhostbusterById(int id) => Ok(ghostbusterService.GetGhostbusterById(id));

    [HttpPost]
    [Route("")]
    public IActionResult CreateGhostbuster([FromBody] GhostbusterInputModel ghostbuster)
    {
        if (!ModelState.IsValid)
        {
            // TODO: Implement and uncomment
            throw new ModelFormatException(ModelState.RetrieveErrorString());
        }
        var newId = ghostbusterService.CreateGhostbuster(ghostbuster);
        return CreatedAtRoute("GetGhostbusterById", new { id = newId }, null);
    }
}