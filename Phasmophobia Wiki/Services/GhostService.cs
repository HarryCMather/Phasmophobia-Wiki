using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer class for the GhostService.
/// </summary>
public class GhostService : IGhostService
{
    private List<Ghost> Ghosts { get; }

    /// <summary>
    /// Ctor for the GhostService.
    /// </summary>
    /// <param name="ghostRepository">Inject the GhostRepository.</param>
    public GhostService(IGhostRepository ghostRepository)
    {
        Ghosts = ghostRepository.GetGhosts().ToList();
    }

    /// <summary>
    /// Get all ghosts.
    /// </summary>
    /// <returns>A list of ghosts retrieved from the filesystem.</returns>
    public List<Ghost> GetGhosts()
    {
        return Ghosts;
    }
}
