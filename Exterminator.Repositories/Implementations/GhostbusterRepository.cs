using System.Collections.Generic;
using System.Linq;
using Exterminator.Models.Dtos;
using Exterminator.Models.Entities;
using Exterminator.Models.InputModels;
using Exterminator.Repositories.Data;
using Exterminator.Repositories.Interfaces;

namespace Exterminator.Repositories.Implementations;

public class GhostbusterRepository(IGhostbusterDbContext dbContext) : IGhostbusterRepository
{
    public int CreateGhostbuster(GhostbusterInputModel ghostbuster)
    {
        var nextId = dbContext.Ghostbusters.Count() + 1;
        dbContext.Ghostbusters.Add(new Ghostbuster
        {
            Id = nextId,
            Name = ghostbuster.Name,
            Expertize = ghostbuster.Expertize
        });

        return nextId;
    }

    public bool DoesExist(int id) => dbContext.Ghostbusters.Any(g => g.Id == id);

    public IEnumerable<GhostbusterDto> GetAllGhostbusters(string expertize) => dbContext.Ghostbusters.Where(g => g.Expertize.ToLower().Contains(expertize.ToLower())).Select(g => new GhostbusterDto
    {
        Id = g.Id,
        Name = g.Name,
        Expertize = g.Expertize
    });

    public GhostbusterDto GetGhostbusterById(int id) => dbContext.Ghostbusters.Where(g => g.Id == id).Select(g => new GhostbusterDto 
    {
        Id = g.Id,
        Name = g.Name,
        Expertize = g.Expertize
    }).ElementAtOrDefault(0);
}