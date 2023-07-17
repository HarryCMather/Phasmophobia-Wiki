using System.ComponentModel.DataAnnotations;

namespace Phasmophobia_Wiki.Models;

/// <summary>
/// A list of settings defined within appsettings.json.
/// </summary>
public class Settings
{
    /// <summary>
    /// Used for identifying the correct appsettings section when binding on start-up.
    /// </summary>
    public const string SectionKey = "Settings";
    
    /// <summary>
    /// The file path of the 'Ghosts.json' file, containing a list of all ghosts in JSON format.
    /// </summary>
    [Required]
    // ReSharper erroneously dictates this can be 'get-only', this cannot be bound in start-up without init or set, it also cannot be null as this is checked on start-up.
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
#pragma warning disable CS8618
    public string GhostsFilePath { get; init; }
#pragma warning restore CS8618
}
