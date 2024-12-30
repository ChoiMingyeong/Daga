using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DagaRemote
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            if (OperatingSystem.IsWindows())
            {
                builder.Services
            }
            else if (OperatingSystem.IsLinux())
            {

            }

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            await host.RunAsync();
        }
    }
}