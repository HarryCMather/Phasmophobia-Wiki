using Microsoft.Net.Http.Headers;
using Phasmophobia_Wiki;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();

// Run the application on port 8000, regardless of what port is set in launchSettings.json
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8000);
});

// Inject and Validate 'Settings'.
builder.Services.AddAndValidateSettings(builder.Configuration);

// Add services to the DI container.
builder.Services.AddPhasmophobiaWikiServices();

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
        const int durationInSeconds = 604800; // 7 days in seconds
        context.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + durationInSeconds;
    }
});

app.UseAuthorization();

app.UseRouting();

app.MapRazorPages();

app.Run();
