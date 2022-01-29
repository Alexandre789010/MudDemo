using Blazored.LocalStorage;
using Microsoft.AspNetCore.Localization;
using MudBlazor.Services;
using MudDemo.Server.Middlewares;
using MudDemo.Server.Models.Localization;
using MudDemo.Server.Services;
using System.Globalization;
using Toolbelt.Blazor.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddHotKeys();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7226/") });
builder.Services.AddTransient<INotificationsService, NotificationsService>();
builder.Services.AddTransient<IArticlesService, ArticlesService>();
builder.Services.AddScoped<LocalizationCookiesMiddleware>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // set the default culture
    //options.DefaultRequestCulture = new RequestCulture("en-US");
    options.AddSupportedUICultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
    options.AddSupportedCultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
    options.FallBackToParentUICultures = true;
});

var app = builder.Build();
app.UseRequestLocalization(options => {
    options.AddSupportedUICultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
    options.AddSupportedCultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
});
app.UseMiddleware<LocalizationCookiesMiddleware>();
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

await app.RunAsync();