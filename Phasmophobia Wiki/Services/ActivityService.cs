using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer class for the ActivityService.
/// </summary>
public class ActivityService : IActivityService
{
    private readonly IGhostService _ghostService;

    // The 'friendly names' for the 'Activity' enum values:
    private const string DOTS = "D.O.T.S Projector";
    private const string EMF = "EMF Level 5";
    private const string Fingerprints = "Fingerprints";
    private const string FreezingTemps = "Freezing Temperatures";
    private const string GhostOrbs = "Ghost Orbs";
    private const string GhostWriting = "Ghost Writing";
    private const string SpiritBox = "Spirit Box";
    
    /// <summary>
    /// Ctor for the 'ActivityService' class.
    /// </summary>
    /// <param name="ghostService">Inject an instance of the ghosts service.</param>
    public ActivityService(IGhostService ghostService)
    {
        _ghostService = ghostService;
    }
    
    /// <summary>
    /// Retrieves the 'friendly name' for a given 'Activity' enum value. 
    /// </summary>
    /// <param name="activity">The 'Activity' enum to retrieve the friendly name for.</param>
    /// <returns>Returns the friendly name for the enum values.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if an int is casted to 'ActivityEnum' that is outside the expected range.</exception>
    public string GetActivityName(Activity activity)
    {
        return activity switch
        {
            Activity.Dots => DOTS,
            Activity.Emf => EMF,
            Activity.Fingerprints => Fingerprints,
            Activity.FreezingTemperatures => FreezingTemps,
            Activity.GhostOrbs => GhostOrbs,
            Activity.GhostWriting => GhostWriting,
            Activity.SpiritBox => SpiritBox,
            _ => throw new ArgumentOutOfRangeException(nameof(activity), activity, "ERROR: An invalid activity was specified.")
        };
    }

    /// <summary>
    /// Returns all possible enum values by their 'friendly name'.
    /// </summary>
    /// <returns>A string list of Activities by it's 'friendly name'.</returns>
    public List<string> GetActivities()
    {
        return Enum.GetValues<Activity>()
            .Select(GetActivityName)
            .ToList();
    }

    /// <summary>
    /// Filter the list of ghosts, returning only the ghosts that have the activities the user has passed in.
    /// </summary>
    /// <param name="activities">The activities/evidence the user has found so far.</param>
    /// <returns>A list of ghosts that possess the traits of the evidence found.</returns>
    public IEnumerable<Ghost> GetGhostsForActivities(List<Activity> activities)
    {
        return _ghostService.GetGhosts().Where(ghost => activities.All(activity => ghost.RequiredActivity.Contains(activity)));
    }
}
