using Microsoft.Net.Http.Headers;
using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;
using Phasmophobia_Wiki.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();

// Run the application on port 8000, regardless of what port is set in launchSettings.json
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8000);
});

// Inject 'Settings'
builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

// Add services to the DI container.
builder.Services.AddSingleton<IGhostRepository, GhostRepository>();

builder.Services.AddSingleton<IGhostService, GhostService>();

builder.Services.AddSingleton<IActivityService, ActivityService>();

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        const int durationInSeconds = 604800;
        context.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
    }
});

app.UseAuthorization();

app.UseRouting();

app.MapRazorPages();

app.Run();
