using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudDemo.Client;
using MudDemo.Client.Services;
using System.Globalization;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddHotKeys();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddBlazoredLocalStorage();

builder.Services.AddTransient<INotificationsService, NotificationsService>();
builder.Services.AddTransient<IArticlesService, ArticlesService>();

var host = builder.Build();
var storageService = host.Services.GetRequiredService<ILocalStorageService>();
if (storageService != null)
{
    var languageCode = await storageService.GetItemAsStringAsync("CurrentLanguage");
    if (languageCode is not null)
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(languageCode);
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(languageCode);
    }
    
}

await host.RunAsync();