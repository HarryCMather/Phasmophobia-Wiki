using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Repositories;

public interface IGhostRepository
{
    /// <summary>
    /// Reads the Ghosts from the 'Ghosts.json' file and returns a deserialized List of type 'Ghost'. 
    /// </summary>
    /// <returns>A list of Ghosts.</returns>
    IEnumerable<Ghost> GetGhosts();
}
