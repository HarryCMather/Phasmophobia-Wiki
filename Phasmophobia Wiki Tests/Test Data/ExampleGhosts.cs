using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki_Tests.Test_Data;

public static class ExampleGhosts
{
    public static HashSet<Ghost> GetExampleGhosts()
    {
        return new HashSet<Ghost>
        {
            new()
            {
                Name = "Test Ghost 1",
                RequiredActivity = Activity.Emf | Activity.Dots
            },
            new()
            {
                Name = "Test Ghost 2",
                RequiredActivity = Activity.Fingerprints | Activity.GhostWriting
            },
            new()
            {
                Name = "Test Ghost 3",
                RequiredActivity = Activity.FreezingTemperatures | Activity.SpiritBox
            }
        };
    }
}