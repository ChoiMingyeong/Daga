using Blazored.SessionStorage;
using DagaKit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace DagaKit;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        if (builder.Configuration["DBUrl"] is not string dbUrl
            || true == string.IsNullOrWhiteSpace(dbUrl))
        {
            throw new Exception("Invalid config");
        }

        builder.Services.AddAuthorizationCore(p =>
        {
            p.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            p.FallbackPolicy = p.DefaultPolicy;
        });
        builder.Services.AddMudServices();
        builder.Services.AddBlazoredSessionStorage();

        builder.Services.AddScoped<DBService>(p => new(new HttpClient
        {
            BaseAddress = new Uri(dbUrl)
        }));
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();

        var app = builder.Build();

        await app.RunAsync();
    }
}