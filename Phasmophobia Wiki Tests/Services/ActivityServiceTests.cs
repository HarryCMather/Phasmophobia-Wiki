using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Phasmophobia_Wiki_Tests.Test_Data;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Services;

namespace Phasmophobia_Wiki_Tests.Services;

public class ActivityServiceTests
{
    [TestCase(Activity.Dots, "D.O.T.S Projector")]
    [TestCase(Activity.Emf, "EMF Level 5")]
    [TestCase(Activity.Fingerprints, "Fingerprints")]
    [TestCase(Activity.FreezingTemperatures, "Freezing Temperatures")]
    [TestCase(Activity.GhostOrbs, "Ghost Orbs")]
    [TestCase(Activity.GhostWriting, "Ghost Writing")]
    [TestCase(Activity.SpiritBox, "Spirit Box")]
    public void GetActivityName_GivenValidActivityEnumValue_ShouldReturnActivityFriendlyName(Activity activity, string expectedActivityFriendlyName)
    {
        // Arrange:
        IGhostService mockGhostService = Substitute.For<IGhostService>();
        IActivityService activityService = new ActivityService(mockGhostService);

        // Act:
        string result = activityService.GetActivityDescriptor(activity);

        // Assert
        result.Should().Be(expectedActivityFriendlyName);
    }

    [Test]
    public void GetActivityName_GivenInvalidActivityEnumValue_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange:
        IGhostService mockGhostService = Substitute.For<IGhostService>();
        IActivityService activityService = new ActivityService(mockGhostService);

        const Activity invalidActivity = (Activity) 25;

        // Act & Assert:
        Assert.Throws<KeyNotFoundException>(() => activityService.GetActivityDescriptor(invalidActivity));
    }

    [Test]
    public void GetActivities_ShouldReturnAllExpectedActivitiesByFriendlyName()
    {
        // Arrange:
        IGhostService mockGhostService = Substitute.For<IGhostService>();
        IActivityService activityService = new ActivityService(mockGhostService);

        List<string> expectedOutput = new()
        {
            "D.O.T.S Projector",
            "EMF Level 5",
            "Fingerprints",
            "Freezing Temperatures",
            "Ghost Orbs",
            "Ghost Writing",
            "Spirit Box"
        };

        // Act:
        List<string> result = activityService.GetAllActivities();

        // Assert:
        result[0].Should().Be(expectedOutput[0]);
        result[1].Should().Be(expectedOutput[1]);
        result[2].Should().Be(expectedOutput[2]);
        result[3].Should().Be(expectedOutput[3]);
        result[4].Should().Be(expectedOutput[4]);
        result[5].Should().Be(expectedOutput[5]);
        result[6].Should().Be(expectedOutput[6]);
    }

    [Test]
    public void GetGhostsForActivities_GivenGhostsContainActivities_ShouldReturnGhosts()
    {
        // Arrange:
        IGhostService mockGhostService = Substitute.For<IGhostService>();
        IActivityService activityService = new ActivityService(mockGhostService);

        HashSet<Ghost> exampleGhosts = ExampleGhosts.GetExampleGhosts().Take(2).ToHashSet();

        mockGhostService.GetGhosts().Returns(exampleGhosts);

        const Activity activities = Activity.Emf | Activity.Dots;

        // Act:
        List<Ghost> results = activityService.GetGhostsForActivities(activities).ToList();

        // Assert:
        results.Should().HaveCount(1);
        
        results[0].Name.Should().Be("Test Ghost 1");
        results[0].RequiredActivity.Should().HaveFlag(Activity.Emf);
        results[0].RequiredActivity.Should().HaveFlag(Activity.Dots);
    }
    
    [Test]
    public void GetGhostsForActivities_GivenGhostsDoesNotContainActivities_ShouldReturnGhost()
    {
        // Arrange:
        IGhostService mockGhostService = Substitute.For<IGhostService>();
        IActivityService activityService = new ActivityService(mockGhostService);

        HashSet<Ghost> exampleGhosts = ExampleGhosts.GetExampleGhosts();

        mockGhostService.GetGhosts().Returns(exampleGhosts);

        const Activity activities = Activity.GhostOrbs;

        // Act:
        IEnumerable<Ghost> results = activityService.GetGhostsForActivities(activities);
        
        // Assert:
        results.Should().BeEmpty();
    }

    [Test]
    public void GetActivitiesByFlags_GivenGhostContainsAllFlagCombinations_ShouldReturnActivitiesList()
    {
        // Arrange:
        IGhostService mockGhostService = Substitute.For<IGhostService>();
        IActivityService activityService = new ActivityService(mockGhostService);

        Ghost ghost = ExampleGhosts.GetExampleGhosts().First();

        List<Activity> expectedActivities = new()
        {
            Activity.Dots,
            Activity.Emf
        };
        
        // Act:
        List<Activity> actualActivities = activityService.GetActivitiesByFlags(ghost.RequiredActivity);
        
        // Assert:
        actualActivities.Should().HaveCount(2);
        actualActivities[0].Should().Be(expectedActivities[0]);
        actualActivities[1].Should().Be(expectedActivities[1]);
    }
}
