using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Services;

namespace Phasmophobia_Wiki.Pages;

/// <summary>
/// Main index page model.
/// </summary>
public class IndexModel : PageModel
{
    private readonly IActivityService _activityService;
    private readonly HashSet<Ghost> _ghosts;

    /// <summary>
    /// Activities that the user has selected, used for determining what ghost types are possible.
    /// </summary>
    [BindProperty]
    public Activity CheckedActivities { get; private set; }
    
    /// <summary>
    /// A list of ints that will be converted to the CheckedActivities above.
    /// </summary>
    [BindProperty]
    public List<int> CheckedBoxes { get; set; } = new();

    /// <summary>
    /// All possible ghosts for the selected activities.
    /// </summary>
    [BindProperty]
    public IEnumerable<Ghost> GhostsForActivities { get; private set; } = Enumerable.Empty<Ghost>();
    
    /// <summary>
    /// The 'friendly' descriptions for the Activity Enum values.
    /// </summary>
    public List<string> ActivityEnumNames { get; private set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="ghostService">Service level logic for getting ghosts.</param>
    /// <param name="activityService">Service level logic for getting activities for ghosts.</param>
    public IndexModel(IGhostService ghostService, IActivityService activityService)
    {
        _ghosts = ghostService.Ghosts;
        _activityService = activityService;
        ActivityEnumNames = _activityService.ActivityDescriptors;
    }

    /// <summary>
    /// A post event made when a user specifies activities through the relevant checkboxes and presses 'Retrieve Possible Ghosts'.
    /// Will result in all relevant ghosts being returned.
    /// </summary>
    public void OnPost()
    {
        // If the user did not select any checkboxes before submitting, do not return any results:
        if (!CheckedBoxes.Any())
        {
            return;
        }

        // As flag enums are used, we can go through each checked item and perform (2 to the power count) to get the flag enum combination:
        CheckedActivities = (Activity) CheckedBoxes.Sum(checkboxValue => Math.Pow(2, checkboxValue));
        
        // Get all ghosts for the selected activities.
        GhostsForActivities = _activityService.GetGhostsForActivities(CheckedActivities);
    }

    /// <summary>
    /// A post event made when the user selects 'List All Ghosts'.  Returns all possible ghosts.
    /// </summary>
    public void OnPostAllGhosts()
    {
        GhostsForActivities = _ghosts;
    }
}