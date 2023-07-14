using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer interface for the ActivityService.
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// Returns all possible enum values by its descriptor.
    /// </summary>
    /// <returns>A string list of Activities by its descriptor.</returns>
    public List<string> ActivityDescriptors { get; }
    
    /// <summary>
    /// Retrieves the descriptor for a given Activity. 
    /// </summary>
    /// <param name="activity">The Activity enum to retrieve the descriptor for.</param>
    /// <returns>Returns the activity's descriptor.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the requested key does not exist. This should, in reality, never be thrown.</exception>
    string GetActivityDescriptor(Activity activity);
    
    /// <summary>
    /// Get all activities from the activities flag enum passed in.
    /// This is required for listing all activities for a given ghost from the flag combination.
    /// </summary>
    /// <param name="activityFlags">The activity combination for a given ghost.</param>
    /// <returns>A list of activities that a ghost possesses.</returns>
    IEnumerable<Activity> GetActivitiesByFlags(Activity activityFlags);
    
    /// <summary>
    /// Filter the list of ghosts, returning only the ghosts that have the activities the user has passed in.
    /// </summary>
    /// <param name="activities">The activities/evidence the user has found so far.</param>
    /// <returns>A list of ghosts that possess the traits of the evidence found.</returns>
    IEnumerable<Ghost> GetGhostsForActivities(Activity activities);
}
