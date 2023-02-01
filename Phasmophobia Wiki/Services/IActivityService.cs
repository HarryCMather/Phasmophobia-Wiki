using Phasmophobia_Wiki.Models;

namespace Phasmophobia_Wiki.Services;

/// <summary>
/// A service layer interface for the ActivityService.
/// </summary>
public interface IActivityService
{
    /// <summary>
    /// Retrieves the 'friendly name' for a given 'Activity' enum value. 
    /// </summary>
    /// <param name="activity">The 'Activity' enum to retrieve the friendly name for.</param>
    /// <returns>Returns the friendly name for the enum values.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if an int is casted to 'ActivityEnum' that is outside the expected range.</exception>
    string GetActivityName(Activity activity);
    
    /// <summary>
    /// Returns all possible enum values by their 'friendly name'.
    /// </summary>
    /// <returns>A string list of Activities by it's 'friendly name'.</returns>
    List<string> GetActivities();
    
    /// <summary>
    /// Filter the list of ghosts, returning only the ghosts that have the activities the user has passed in.
    /// </summary>
    /// <param name="activities">The activities/evidence the user has found so far.</param>
    /// <returns>A list of ghosts that possess the traits of the evidence found.</returns>
    List<Ghost> GetGhostsForActivities(List<Activity> activities);
}
