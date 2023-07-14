using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer class for the GhostService.
/// </summary>
public class GhostService : IGhostService
{
    /// <summary>
    /// A list of ghosts retrieved from the filesystem through the repository layer.
    /// </summary>
    public HashSet<Ghost> Ghosts { get; }

    /// <summary>
    /// Ctor for the GhostService.
    /// </summary>
    /// <param name="ghostRepository">Inject the GhostRepository.</param>
    public GhostService(IGhostRepository ghostRepository)
    {
        Ghosts = ghostRepository.GetGhosts();
    }
}
