using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;

namespace Phasmophobia_Wiki.Services;

public class GhostService : IGhostService
{
    public List<string> ActivityEnumNames { get; }

    public List<Ghost> Ghosts { get; }

    public GhostService(IGhostRepository ghostRepository)
    {
        Ghosts = ghostRepository.GetGhosts().ToList();
        ActivityEnumNames = Activity.GetActivities();
    }
}
