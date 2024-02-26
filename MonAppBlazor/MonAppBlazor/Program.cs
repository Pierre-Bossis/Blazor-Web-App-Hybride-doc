using MonAppBlazor.Client.Pages;
using MonAppBlazor.Components;
using MonAppBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<ProduitsService>();

builder.Services.AddHttpClient("Api", config =>
{
    config.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
    config.BaseAddress = new Uri("https://localhost:7038/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode()
//    .AddInteractiveWebAssemblyRenderMode()
//    .AddAdditionalAssemblies(typeof(MonAppBlazor.Client._Imports).Assembly);

//pour que les @page marchent en les définissant dans la bibliothèque Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
    typeof(MonAppBlazor.Client._Imports).Assembly,
    typeof(MonAppBlazor.Components.Counter).Assembly
    );

app.Run();
