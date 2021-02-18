using BlazorFluentUI;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using MudBlazor.Services;
using System.Globalization;

namespace GIDB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazorFluentUI();
            builder.Services.AddMudServices();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            AppEnvironment.genshinDB = new GenshinDB_Core.GenshinDB(CultureInfo.GetCultureInfo("ko-KR"));

            await builder.Build().RunAsync();
        }
    }
}
