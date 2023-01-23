using Phasmophobia_Wiki.Repositories;
using Phasmophobia_Wiki.Services;

// DataPopulator.PopulateData();
// ActivityPopulator.PopulateData();
// return;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8000);
});

// Add services to the container.
builder.Services.AddSingleton<IGhostRepository, GhostRepository>();

builder.Services.AddSingleton<IGhostService, GhostService>();

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
