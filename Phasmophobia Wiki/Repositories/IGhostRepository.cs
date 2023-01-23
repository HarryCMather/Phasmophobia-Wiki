using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Repositories;

public interface IGhostRepository
{
    IEnumerable<Ghost> GetGhosts();
}