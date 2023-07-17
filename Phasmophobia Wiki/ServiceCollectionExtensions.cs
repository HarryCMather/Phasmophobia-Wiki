using System.Text.Json;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;
using Phasmophobia_Wiki.Services;

// ReSharper disable InconsistentNaming
namespace Phasmophobia_Wiki;

/// <summary>
/// Service collection logic.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds and Validates the 'Settings' options on start-up, to ensure the application can function correctly.
    /// The application will quit if validation fails.
    /// </summary>
    /// <param name="serviceCollection">Used for injecting the required Settings Options into the application.</param>
    /// <param name="configuration">Used for obtaining the Settings section from within appsettings.</param>
    public static void AddAndValidateSettings(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddOptions<Settings>()
            .Bind(configuration.GetRequiredSection(Settings.SectionKey)) // Ensure the 'Settings' section exists.
            .ValidateDataAnnotations() // Validate that the 'GhostsFilePath' has been specified in appsettings.
            .Validate(settings =>
            {
                // If validation logic returns true, validation was successful, otherwise it failed.
                
                if (settings is null || string.IsNullOrEmpty(settings.GhostsFilePath)) // Validate the Settings and GhostsFilePath contain values
                {
                    return false;
                }

                if (!settings.GhostsFilePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase) || // Validate 'GhostsFilePath' is a JSON file and that it exists.
                    !File.Exists(settings.GhostsFilePath))
                {
                    return false;
                }

                // Validate the JSON file contains at least 1 ghost:
                string json = File.ReadAllText(settings.GhostsFilePath);
                Ghost[]? ghosts = JsonSerializer.Deserialize<Ghost[]>(json);

                if (ghosts is null || ghosts.Length == 0)
                {
                    throw new FileLoadException($"The file path {settings.GhostsFilePath} contains no ghosts.", settings.GhostsFilePath);
                }

                return true;
            }) 
            .ValidateOnStart();
    }

    /// <summary>
    /// Adds the appropriate service and repository layers into the application.
    /// </summary>
    /// <param name="serviceCollection">Used for injecting the Service and Repository layers into the application through DI.</param>
    public static void AddPhasmophobiaWikiServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IGhostRepository, GhostRepository>();
        serviceCollection.AddSingleton<IGhostService, GhostService>();
        serviceCollection.AddSingleton<IActivityService, ActivityService>();
    }
}
