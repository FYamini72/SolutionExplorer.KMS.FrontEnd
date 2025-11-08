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

            //var culture = new CultureInfo("fa-IR");
            //CultureInfo.DefaultThreadCurrentCulture = culture;
            //CultureInfo.DefaultThreadCurrentUICulture = culture;

            ConfigurePersianCulture();

            services.AddMudServices();
            services.AddSingleton<MudLocalizer, DictionaryMudLocalizer>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif
        }

        private static void ConfigurePersianCulture()
        {
            var culture = new CultureInfo("fa-IR");

            // تنظیمات تاریخ
            culture.DateTimeFormat.Calendar = new PersianCalendar();
            culture.DateTimeFormat.AbbreviatedDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            culture.DateTimeFormat.ShortestDayNames = new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
            culture.DateTimeFormat.DayNames = new[] { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };

            var monthNames = new[]
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", ""
            };

            culture.DateTimeFormat.MonthNames = monthNames;
            culture.DateTimeFormat.AbbreviatedMonthNames = monthNames;
            culture.DateTimeFormat.MonthGenitiveNames = monthNames;
            culture.DateTimeFormat.AbbreviatedMonthGenitiveNames = monthNames;

            culture.DateTimeFormat.AMDesignator = "ق.ظ";
            culture.DateTimeFormat.PMDesignator = "ب.ظ";
            culture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
            culture.DateTimeFormat.LongDatePattern = "dddd, d MMMM yyyy";
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Saturday;

            //// تنظیمات عدد
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.NumberGroupSeparator = ",";
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
            culture.NumberFormat.CurrencyGroupSeparator = ",";
            culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
            culture.NumberFormat.NativeDigits = new[] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

            // اعمال فرهنگ به صورت سراسری
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
