using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using SolutionExplorer.KMS.SharedUI.Resources;
using SolutionExplorer.KMS.SharedUI.Services.Implementations;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using SolutionExplorer.KMS.WebUI;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient());
builder.Services.AddScoped<IHttpService, HttpService>();

var culture = new CultureInfo("fa-IR");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

builder.Services.AddMudServices();
builder.Services.AddSingleton<MudLocalizer, DictionaryMudLocalizer>();
//builder.Services.AddScoped<SpinnerService>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

await builder.Build().RunAsync();
