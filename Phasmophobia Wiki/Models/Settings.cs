namespace Phasmophobia_Wiki.Models;

/// <summary>
/// A list of settings defined within appsettings.json.
/// </summary>
public class Settings
{
    /// <summary>
    /// The file path of the 'Ghosts.json' file, containing a list of all ghosts in JSON format.
    /// </summary>
    public string GhostsFilePath { get; set; }
}