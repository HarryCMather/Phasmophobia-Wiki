using System.Text.Json;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;

namespace Phasmophobia_Wiki.DataPopulator;

/// <summary>
/// This class has been created for the sole purpose of assisting with the editing of the Ghosts.json file.
/// This will not be used by default when the Web App starts up, and will need to uncommented to be injected within 'Program.cs'
/// </summary>
public class ActivityPopulator
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    public static void PopulateData()
    {
        List<Ghost> ghosts = new();
        string ghostsJson = string.Empty;

        if (!File.Exists(GhostRepository.FilePath)) return;

        ghostsJson = File.ReadAllText(GhostRepository.FilePath);
        List<Ghost> existingGhosts = JsonSerializer.Deserialize<List<Ghost>>(ghostsJson, JsonSerializerOptions) ?? new List<Ghost>();

        ghosts = UpdateActivities(existingGhosts);
        ghostsJson = JsonSerializer.Serialize(ghosts);
        File.WriteAllText(GhostRepository.FilePath, ghostsJson);
    }

    private static List<Ghost> UpdateActivities(List<Ghost> existingGhosts)
    {
        foreach (Ghost ghost in existingGhosts)
        {
            Console.WriteLine($"Updating ghost: {ghost.Name}");
            ghost.RequiredActivity = UpdateActivity().ToList();
        }

        return existingGhosts;
    }

    private static IEnumerable<ActivityEnum> UpdateActivity()
    {
        List<string> activities = Activity.GetActivities();
        Console.WriteLine("Enter the number corresponding to the activity you wish to add:");
        for (int count = 0; count < 3; count++)
        {
            OutputActivities(activities);
            yield return (ActivityEnum) (int.Parse(Console.ReadLine()) - 1);
        }
    }

    private static void OutputActivities(List<string> activities)
    {
        for (int count = 0; count < activities.Count; count++)
        {
            Console.WriteLine($"{count+1} - {activities[count]}");
        }
    }
}