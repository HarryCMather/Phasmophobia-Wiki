namespace Phasmophobia_Wiki.Models;

/// <summary>
/// A model for storing common properties for ghosts.
/// </summary>
public class Ghost
{
    /// <summary>
    /// The ghost's name.
    /// </summary>
    public string Name { get; init; } = string.Empty;
    
    /// <summary>
    /// The ghost's summary, as provided in-game.
    /// </summary>
    public string Summary { get; init; } = string.Empty;
    
    /// <summary>
    /// Traits that make the ghost easier to recognize.
    /// </summary>
    public List<string> Advantages { get; init; } = new();
    
    /// <summary>
    /// What the ghost is afraid of, or how it makes itself less likely to be caught.
    /// </summary>
    public List<string> Disadvantages { get; init; } = new();
    
    /// <summary>
    /// Any additional information, not provided in-game which can assist in determining the ghost type.
    /// </summary>
    public List<string> AdditionalDetails { get; init; } = new();
    
    /// <summary>
    /// A flag enum combination of evidence required for the given ghost type.
    /// </summary>
    public Activity RequiredActivity { get; init; }
}
