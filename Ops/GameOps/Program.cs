using Blazored.SessionStorage;
using GameOps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace GameOps
{
    public class Program
    {
        public static async Task Main(string[] args)
        {            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddAuthorizationCore(p =>
            {
                p.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                p.FallbackPolicy = p.DefaultPolicy;
            });
            builder.Services.AddBlazoredSessionStorage();

            builder.Services.AddScoped<GateHubService>(p => new(new HttpClient { BaseAddress = new Uri("https://localhost:9002") }));
            builder.Services.AddScoped<DBService>(p => new(new HttpClient { BaseAddress = new Uri("https://localhost:9102") }));
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();

            var app = builder.Build();


            await app.RunAsync();
        }
    }
}
