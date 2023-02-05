using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer interface for the GhostService.
/// </summary>
public interface IGhostService
{
    /// <summary>
    /// Get all ghosts.
    /// </summary>
    /// <returns>A list of ghosts retrieved from the filesystem.</returns>
    HashSet<Ghost> GetGhosts();
}