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
    private readonly Dictionary<Activity, string> _activityDescriptorMapping;
    private readonly Activity[] _activityValues;
    
    /// <summary>
    /// Returns all possible enum values by its descriptor.
    /// </summary>
    /// <returns>A string list of Activities by its descriptor.</returns>
    public List<string> ActivityDescriptors { get; } = new();
    
    /// <summary>
    /// Ctor for the 'ActivityService' class.
    /// </summary>
    /// <param name="ghostService">Inject an instance of the ghosts service.</param>
    public ActivityService(IGhostService ghostService)
    {
        _ghostService = ghostService;
        _activityValues = Enum.GetValues<Activity>();
        _activityDescriptorMapping = GetActivityDescriptions();
    }
    
    private Dictionary<Activity, string> GetActivityDescriptions()
    {
        Dictionary<Activity, string> activityDescriptorMappings = new();

        Type activityType = typeof(Activity);
        
        // Whilst the use of reflection is slow, this class is a singleton and this logic is being performed once upon instantiation, so this is not a performance penalty. 
        foreach (Activity activity in _activityValues)
        {
            FieldInfo fieldInfo = activityType.GetField(activity.ToString())!;
            
            string activityDescription = ((DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute)))[0].Description;
            
            activityDescriptorMappings.Add(activity, activityDescription);
            ActivityDescriptors.Add(activityDescription);
        }

        return activityDescriptorMappings;
    }

    /// <summary>
    /// Retrieves the descriptor for a given Activity. 
    /// </summary>
    /// <param name="activity">The Activity enum to retrieve the descriptor for.</param>
    /// <returns>Returns the activity's descriptor.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the requested key does not exist. This should, in reality, never be thrown.</exception>
    public string GetActivityDescriptor(Activity activity)
    {
        return _activityDescriptorMapping[activity];
    }

    /// <summary>
    /// Get all activities from the activities flag enum passed in.
    /// This is required for listing all activities for a given ghost from the flag combination.
    /// </summary>
    /// <param name="activityFlags">The activity combination for a given ghost.</param>
    /// <returns>A list of activities that a ghost possesses.</returns>
    public IEnumerable<Activity> GetActivitiesByFlags(Activity activityFlags)
    {
        return _activityValues
            .Cast<Enum>()
            .Where(activityFlags.HasFlag)
            .Cast<Activity>();
    }

    /// <summary>
    /// Filter the list of ghosts, returning only the ghosts that have the activities the user has passed in.
    /// </summary>
    /// <param name="activities">The activities/evidence the user has found so far.</param>
    /// <returns>A list of ghosts that possess the traits of the evidence found.</returns>
    public IEnumerable<Ghost> GetGhostsForActivities(Activity activities)
    {
        return _ghostService.Ghosts
            .Where(ghost => ghost.RequiredActivity.HasFlag(activities));
    }
}
