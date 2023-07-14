using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer interface for the GhostService.
/// </summary>
public interface IGhostService
{
    /// <summary>
    /// A list of ghosts retrieved from the filesystem through the repository layer.
    /// </summary>
    HashSet<Ghost> Ghosts { get; }
}
