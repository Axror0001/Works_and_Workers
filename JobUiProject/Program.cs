using Blazorise;
using Blazorise.Bootstrap;
using JobsUI.Service;
using JobUiProject.Data;
using Syncfusion.Blazor;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<EmployeeServiceUI>();
builder.Services.AddTransient<JobServiceUI>();
builder.Services.AddTransient<LevelServiceUI>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazorise();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true; // Kutilmagan holatlarni oldini olish
    })
    .AddBootstrapProviders(); // Bootstrap yoki boshqa variantni tanlang

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri("https://localhost:7109/") });
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
