namespace Phasmophobia_Wiki.Models;

public class Ghost
{
    public string Name { get; init; } = string.Empty;
    public string Summary { get; init; } = string.Empty;
    public List<string> Advantages { get; init; } = new();
    public List<string> Disadvantages { get; init; } = new();
    public List<string> AdditionalDetails { get; init; } = new();
    public List<Activity> RequiredActivity { get; set; } = new();
}
