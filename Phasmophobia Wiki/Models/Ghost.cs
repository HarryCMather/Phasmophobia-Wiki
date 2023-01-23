namespace Phasmophobia_Wiki.Models;

public class Ghost
{
    public string Name { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public List<string> Advantages { get; set; } = new();
    public List<string> Disadvantages { get; set; } = new();
    public List<string> AdditionalDetails { get; set; } = new();
    public List<ActivityEnum> RequiredActivity { get; set; } = new();
}
