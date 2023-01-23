namespace Phasmophobia_Wiki.Models;

public static class Activity
{
    private const string DOTS = "D.O.T.S Projector";
    private const string EMF = "EMF Level 5";
    private const string Fingerprints = "Fingerprints";
    private const string FreezingTemps = "Freezing Temperatures";
    private const string GhostOrbs = "Ghost Orbs";
    private const string GhostWriting = "Ghost Writing";
    private const string SpiritBox = "Spirit Box";

    public static string GetActivityName(ActivityEnum activity)
    {
        return activity switch
        {
            ActivityEnum.Dots => DOTS,
            ActivityEnum.Emf => EMF,
            ActivityEnum.Fingerprints => Fingerprints,
            ActivityEnum.FreezingTemperatures => FreezingTemps,
            ActivityEnum.GhostOrbs => GhostOrbs,
            ActivityEnum.GhostWriting => GhostWriting,
            ActivityEnum.SpiritBox => SpiritBox,
            _ => throw new ArgumentOutOfRangeException(nameof(activity), activity, null)
        };
    }

    public static List<string> GetActivities()
    {
        return Enum.GetValues<ActivityEnum>()
            .Select(GetActivityName)
            .ToList();
    }

    public static List<Ghost> GetGhostsForActivities(List<Ghost> allGhosts, List<ActivityEnum> activities)
    {
        return allGhosts.Where(ghost => activities.All(activity => ghost.RequiredActivity.Contains(activity))).ToList();
    }
}

public enum ActivityEnum
{
    Dots,
    Emf,
    Fingerprints,
    FreezingTemperatures,
    GhostOrbs,
    GhostWriting,
    SpiritBox
}
