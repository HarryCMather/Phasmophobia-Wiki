using System.Text.Json;
using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Repositories;

public class GhostRepository : IGhostRepository
{
    public const string FilePath = "Ghosts.json";

    public IEnumerable<Ghost> GetGhosts()
    {
        if (!File.Exists(FilePath))
        {
            return Enumerable.Empty<Ghost>();
        }
        
        string json = File.ReadAllText(FilePath);
        List<Ghost>? ghosts = JsonSerializer.Deserialize<List<Ghost>>(json);

        if (ghosts is null || !ghosts.Any())
        {
            return Enumerable.Empty<Ghost>();
        }

        return ghosts;
    }
}