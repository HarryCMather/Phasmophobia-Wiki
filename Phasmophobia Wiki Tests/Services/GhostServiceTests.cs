using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Phasmophobia_Wiki_Tests.Test_Data;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;
using Phasmophobia_Wiki.Services;

namespace Phasmophobia_Wiki_Tests.Services;

public class GhostServiceTests
{
    [Test]
    public void GetGhosts_ShouldReturnPopulatedGhostsList()
    {
        // Arrange:
        IGhostRepository mockGhostRepository = Substitute.For<IGhostRepository>();
        mockGhostRepository.GetGhosts().Returns(ExampleGhosts.GetExampleGhosts());

        IGhostService ghostService = new GhostService(mockGhostRepository);
        
        // Act:
        HashSet<Ghost> ghosts = ghostService.Ghosts;

        // Assert:
        ghosts.Should().HaveCount(ExampleGhosts.GetExampleGhosts().Count);
    }
}
