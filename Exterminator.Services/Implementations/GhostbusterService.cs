using System;
using System.Collections.Generic;
using Exterminator.Models.Dtos;
using Exterminator.Models.Exceptions;
using Exterminator.Models.InputModels;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Interfaces;

namespace Exterminator.Services.Implementations;

public class GhostbusterService(IGhostbusterRepository ghostbusterRepository) : IGhostbusterService
{
    public int CreateGhostbuster(GhostbusterInputModel ghostbuster) => ghostbusterRepository.CreateGhostbuster(ghostbuster);

    public IEnumerable<GhostbusterDto> GetAllGhostbusters(string expertize = "") => ghostbusterRepository.GetAllGhostbusters(expertize);

    public GhostbusterDto GetGhostbusterById(int id)
    {
        if (id < 1) { throw new ArgumentOutOfRangeException("Id should not be lower than 1"); }
        if (!ghostbusterRepository.DoesExist(id))
        {
            // TODO: Implement and uncomment
            throw new ResourceNotFoundException($"Ghostbuster with id {id} was not found.");
        }
        return ghostbusterRepository.GetGhostbusterById(id);
    }
}