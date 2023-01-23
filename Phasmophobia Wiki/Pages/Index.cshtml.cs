using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Services;

namespace Phasmophobia_Wiki.Pages;

public class IndexModel : PageModel
{
    private readonly List<Ghost> _ghosts;

    private List<ActivityEnum> CheckedActivities = new();
    
    [BindProperty]
    public List<int> CheckedBoxes { get; set; } = new();

    [BindProperty]
    public List<Ghost> GhostsForActivities { get; private set; } = new();
    
    public List<string> ActivityEnumNames { get; private set; }

    public IndexModel(IGhostService ghostService)
    {
        _ghosts = ghostService.Ghosts;
        ActivityEnumNames = ghostService.ActivityEnumNames;
    }

    public void OnPost()
    {
        CheckedActivities = CheckedBoxes.Select(value => (ActivityEnum)value).ToList();
        GhostsForActivities = Activity.GetGhostsForActivities(_ghosts, CheckedActivities);
    }

    public void OnPostAllGhosts()
    {
        GhostsForActivities = _ghosts;
    }
}