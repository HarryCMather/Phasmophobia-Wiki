using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Services;

namespace Phasmophobia_Wiki.Pages;

public class IndexModel : PageModel
{
    private readonly IActivityService _activityService;
    private readonly HashSet<Ghost> _ghosts;

    [BindProperty]
    public Activity CheckedActivities { get; private set; }
    
    [BindProperty]
    public List<int> CheckedBoxes { get; set; } = new();

    [BindProperty]
    public IEnumerable<Ghost> GhostsForActivities { get; private set; } = Enumerable.Empty<Ghost>();
    
    public List<string> ActivityEnumNames { get; private set; }

    public IndexModel(IGhostService ghostService, IActivityService activityService)
    {
        _ghosts = ghostService.GetGhosts();
        _activityService = activityService;
        ActivityEnumNames = _activityService.GetAllActivities();
    }

    public void OnPost()
    {
        // If the user did not select any checkboxes before submitting, do not return any results:
        if (!CheckedBoxes.Any())
        {
            return;
        }

        CheckedActivities = (Activity) CheckedBoxes.Sum(checkboxValue => Math.Pow(2, checkboxValue));
        
        GhostsForActivities = _activityService.GetGhostsForActivities(CheckedActivities);
    }

    public void OnPostAllGhosts()
    {
        GhostsForActivities = _ghosts;
    }
}