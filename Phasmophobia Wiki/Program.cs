using Phasmophobia_Wiki.Models;
using Phasmophobia_Wiki.Repositories;
using Phasmophobia_Wiki.Services;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();
