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
                RequiredActivity = new List<Activity>
                {
                    Activity.Emf,
                    Activity.Dots
                }
            },
            new()
            {
                Name = "Test Ghost 2",
                RequiredActivity = new List<Activity>
                {
                    Activity.Fingerprints,
                    Activity.GhostWriting
                }
            },
            new()
            {
                Name = "Test Ghost 3",
                RequiredActivity = new List<Activity>
                {
                    Activity.FreezingTemperatures,
                    Activity.SpiritBox
                }
            }
        };
    }
}