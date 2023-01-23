using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

public interface IGhostService
{
    List<string> ActivityEnumNames { get; }
    List<Ghost> Ghosts { get; }
}