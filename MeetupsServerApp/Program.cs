using MeetupsServerApp.Data;
using MeetupsServerApp.Features.CreateEvent;
using MeetupsServerApp.Features.ViewCreatedEvents;
using MeetupsServerApp.Shared;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddTransient<CreateEventService>();
builder.Services.AddTransient<ViewCreatedEventsService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Configure DbContext
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var persianCulture = CultureInfo.GetCultureInfo("fa-IR").Clone() as CultureInfo;
persianCulture.DateTimeFormat.Calendar = new PersianCalendar();
persianCulture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;

CultureInfo.DefaultThreadCurrentCulture = persianCulture;
CultureInfo.DefaultThreadCurrentUICulture = persianCulture;

var supportedCultures = new[] { new CultureInfo("fa-IR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("fa-IR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.Run();
