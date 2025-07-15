using Blazored.LocalStorage;
using Manager.UI.ClientServiceClasses;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Manager.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddScoped(sp=>new HttpClient { BaseAddress = new Uri("https://localhost:7113/") });
            builder.Services.AddScoped<UserServiceClient>();
            builder.Services.AddScoped<CurrentUserService>();
            builder.Services.AddScoped<TaskEntityServiceClient>();
            builder.Services.AddScoped<WorkWithToken>();
            builder.Services.AddBlazoredLocalStorage();
            await builder.Build().RunAsync();

        }
    }
}
