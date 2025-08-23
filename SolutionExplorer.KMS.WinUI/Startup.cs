using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor;
using MudBlazor.Services;
using SolutionExplorer.KMS.SharedUI.Resources;
using SolutionExplorer.KMS.SharedUI.Services.Implementations;
using SolutionExplorer.KMS.SharedUI.Services.Interfaces;
using System.Globalization;

namespace SolutionExplorer.KMS.WinUI
{
    public static class Startup
    {
        public static IServiceProvider? Services { get; private set; }

        public static void Init()
        {
            var host = Host.CreateDefaultBuilder()
                           .ConfigureServices(WireupServices)
                           .Build();
            Services = host.Services;
        }

        private static void WireupServices(IServiceCollection services)
        {
            services.AddWindowsFormsBlazorWebView();
            services.AddScoped(sp => new HttpClient());
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthorizationCore();

            var culture = new CultureInfo("fa-IR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            services.AddMudServices();
            services.AddSingleton<MudLocalizer, DictionaryMudLocalizer>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif
        }
    }
}
