using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;
using Phasmophobia_Wiki.Services;

// Leaving this commented out, so it can be easily added back in the future:
// IOptions<Settings> settings = Options.Create(new Settings
// {
//     GhostsFilePath = "./ghosts.json"
// });
// DataPopulator dataPopulator = new(settings);
// ActivityPopulator activityPopulator = new(settings);
// dataPopulator.PopulateData();
// activityPopulator.PopulateData();
// return;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< Updated upstream
// Run the application on port 8000, regardless of what port is set in launchsettings.json
=======
builder.Services.AddResponseCompression();

// Run the application on port 8000, regardless of what port is set in launchSettings.json
>>>>>>> Stashed changes
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8000);
});

// Inject 'Settings'
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

// Add services to the DI container.
builder.Services.AddSingleton<IGhostRepository, GhostRepository>();

builder.Services.AddSingleton<IGhostService, GhostService>();

builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
