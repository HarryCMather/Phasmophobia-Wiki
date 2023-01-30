using System.Text;
using System.Text.Json;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;

namespace Phasmophobia_Wiki.DataPopulator;

/// <summary>
/// This class has been created for the sole purpose of assisting with the editing of the Ghosts.json file.
/// This will not be used by default when the Web App starts up, and will need to uncommented to be injected within 'Program.cs'
/// </summary>
public static class DataPopulator
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    public static void PopulateData()
    {
        List<Ghost> ghosts = new();
        string ghostsJson = string.Empty;
        
        if (File.Exists(GhostRepository.FilePath))
        {
            ghostsJson = File.ReadAllText(GhostRepository.FilePath);
            List<Ghost> existingGhosts = JsonSerializer.Deserialize<List<Ghost>>(ghostsJson, JsonSerializerOptions) ?? new List<Ghost>();
            ghosts.AddRange(existingGhosts);
        }
        
        ghosts.AddRange(GetGhosts().ToList());
        ghostsJson = JsonSerializer.Serialize(ghosts);
        File.WriteAllText(GhostRepository.FilePath, ghostsJson);
    }

    private static IEnumerable<Ghost> GetGhosts()
    {
        while (true)
        {
            Ghost? ghost = GetGhost();
            if (ghost is null) break;
            yield return ghost;
        }
    }

    private static Ghost? GetGhost()
    {
        Console.WriteLine("Enter the ghost's name, or type 'END' to break:");
        string name = Console.ReadLine() ?? string.Empty;

        if (string.Equals(name, "END", StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        Ghost ghost = new()
        {
            Name = name,
            Summary = GetMultiLineInput("Enter a summary for the ghost, this allows for multiple lines. Type 'END' to stop:"),
            Advantages = GetEnumerableInput("Enter the ghosts advantages with each item on a new line. Type 'END' to stop:").ToList(),
            Disadvantages = GetEnumerableInput("Enter the ghosts disadvantages with each item on a new line. Type 'END' to stop:").ToList(),
            AdditionalDetails = GetEnumerableInput("Enter any additional details with each item on a new line. Type 'END' to stop:").ToList(),
            RequiredActivity = GetRequiredActivity().ToList()
        };

        return ghost;
    }

    private static string GetMultiLineInput(string prompt)
    {
        StringBuilder stringBuilder = new();
        Console.WriteLine(prompt);
        while (true)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (string.Equals(input, "END", StringComparison.OrdinalIgnoreCase))
            {
                return stringBuilder.ToString();
            }
            stringBuilder.Append(input);
        }
    }

    private static IEnumerable<string> GetEnumerableInput(string prompt)
    {
        Console.WriteLine(prompt);
        while (true)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (string.Equals(input, "END", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            yield return input;
        }
    }

    private static IEnumerable<ActivityEnum> GetRequiredActivity()
    {
        List<string> activities = Activity.GetActivities();

        while (true)
        {
            Console.WriteLine("The following activities are available, enter the number to the left of the activity name, or type 'END' to stop:");
            
            for (int count = 0; count < activities.Count; count++)
            {
                Console.WriteLine($"\t{count + 1} - {activities[count]}");
            }
            
            string input = Console.ReadLine() ?? string.Empty;
            if (string.Equals(input, "END", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            if (!int.TryParse(input, out int inputCount))
            {
                Console.WriteLine("Error: You did not enter a number. Try again.");
                continue;
            }
            
            inputCount--;
            if (inputCount >= 0 && inputCount < activities.Count)
            {
                activities.RemoveAt(inputCount);
                yield return (ActivityEnum)inputCount;
            }
            else
            {
                Console.WriteLine($"Error: Input was not between 1 and {activities.Count}");   
            }
        }
    }
}
