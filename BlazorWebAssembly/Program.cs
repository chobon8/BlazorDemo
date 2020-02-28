using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor.Hosting;
using Blazor.App.Layout;
using Blazor.App.View;
using Skclusive.Material.Component;

namespace BlazorWebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddMaterialUI();

            builder.Services.AddLayout(new LayoutConfigBuilder().WithResponsive(true).Build());

            await builder.Build().RunAsync();
        }
    }
}
