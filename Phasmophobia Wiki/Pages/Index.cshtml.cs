using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Services;

namespace Phasmophobia_Wiki.Pages;

public class IndexModel : PageModel
{
    private readonly IActivityService _activityService;
    private readonly List<Ghost> _ghosts;

    private List<ActivityEnum> _checkedActivities = new();
    
    [BindProperty]
    public List<int> CheckedBoxes { get; set; } = new();

    [BindProperty]
    public List<Ghost> GhostsForActivities { get; private set; } = new();
    
    public List<string> ActivityEnumNames { get; private set; }

    public IndexModel(IGhostService ghostService, IActivityService activityService)
    {
        _ghosts = ghostService.GetGhosts();
        _activityService = activityService;
        ActivityEnumNames = _activityService.GetActivities();
    }

    public void OnPost()
    {
        _checkedActivities = CheckedBoxes.Select(value => (ActivityEnum)value).ToList();
        
        // If the user did not select any checkboxes before submitting, do not return any results:
        if (!_checkedActivities.Any())
        {
            return;
        }
        
        GhostsForActivities = _activityService.GetGhostsForActivities(_checkedActivities);
    }

    public void OnPostAllGhosts()
    {
        GhostsForActivities = _ghosts;
    }
}