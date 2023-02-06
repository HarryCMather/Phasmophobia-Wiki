using System.ComponentModel;
using System.Reflection;
using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer class for the ActivityService.
/// </summary>
public class ActivityService : IActivityService
{
    private readonly IGhostService _ghostService;
    private readonly Dictionary<Activity, string> _activityFriendlyNames;
    private readonly Activity[] _activityValues;
    
    /// <summary>
    /// Ctor for the 'ActivityService' class.
    /// </summary>
    /// <param name="ghostService">Inject an instance of the ghosts service.</param>
    public ActivityService(IGhostService ghostService)
    {
        _ghostService = ghostService;
        _activityValues = Enum.GetValues<Activity>();
        _activityFriendlyNames = GetActivityDescriptions();
    }
    
    private Dictionary<Activity, string> GetActivityDescriptions()
    {
        Dictionary<Activity, string> activityDescriptors = new();

        Type activityType = typeof(Activity);
        
        foreach (Activity activity in _activityValues)
        {
            FieldInfo fieldInfo = activityType.GetField(activity.ToString())!;
            
            string activityDescription = ((DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute)))[0].Description;
            
            activityDescriptors.Add(activity, activityDescription);
        }

        return activityDescriptors;
    }

    /// <summary>
    /// Retrieves the descriptor for a given Activity. 
    /// </summary>
    /// <param name="activity">The Activity enum to retrieve the descriptor for.</param>
    /// <returns>Returns the activity's descriptor.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the requested key does not exist. This should, in reality, never be thrown.</exception>
    public string GetActivityDescriptor(Activity activity)
    {
        return _activityFriendlyNames[activity];
    }

    /// <summary>
    /// Returns all possible enum values by its descriptor.
    /// </summary>
    /// <returns>A string list of Activities by its descriptor.</returns>
    public List<string> GetAllActivities()
    {
        return _activityValues
            .Select(GetActivityDescriptor)
            .ToList();
    }

    /// <summary>
    /// Get all activities from the activities flag enum passed in.
    /// This is required for listing all activities for a given ghost from the flag combination.
    /// </summary>
    /// <param name="activityFlags">The activity combination for a given ghost.</param>
    /// <returns>A list of activities that a ghost possesses.</returns>
    public List<Activity> GetActivitiesByFlags(Activity activityFlags)
    {
        return _activityValues
            .Cast<Enum>()
            .Where(activityFlags.HasFlag)
            .Cast<Activity>()
            .ToList();
    }

    /// <summary>
    /// Filter the list of ghosts, returning only the ghosts that have the activities the user has passed in.
    /// </summary>
    /// <param name="activities">The activities/evidence the user has found so far.</param>
    /// <returns>A list of ghosts that possess the traits of the evidence found.</returns>
    public IEnumerable<Ghost> GetGhostsForActivities(Activity activities)
    {
        return _ghostService.GetGhosts()
            .Where(ghost => ghost.RequiredActivity.HasFlag(activities));
    }
}
