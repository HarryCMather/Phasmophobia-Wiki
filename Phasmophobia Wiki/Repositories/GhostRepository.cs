using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Repositories;

/// <summary>
/// Repository class to handle reading Ghosts from the filesystem.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Cannot currently unit test the repository layer.")]
public class GhostRepository : IGhostRepository
{
    /// <summary>
    /// The file path of the JSON file to read.
    /// This is public, as it's also used in the DataPopulator.cs and ActivityPopulator.cs static classes.
    /// </summary>
    private readonly string _filePath;

    public GhostRepository(IOptions<Settings> settings)
    {
        _filePath = settings.Value.GhostsFilePath;
    }
    
    /// <summary>
    /// Reads the Ghosts from the 'Ghosts.json' file and returns a deserialized List of type 'Ghost'. 
    /// </summary>
    /// <returns>A list of Ghosts.</returns>
    public HashSet<Ghost> GetGhosts()
    {
        HashSet<Ghost>? ghosts = null;
        
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            ghosts = JsonSerializer.Deserialize<HashSet<Ghost>>(json);    
        }
        
        return ghosts ?? new HashSet<Ghost>();
    }
}
