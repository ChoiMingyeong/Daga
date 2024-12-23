using DagaRemote.Hub;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace DagaRemote
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HubConnection _hubConnection;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://dagaops.duckdns.org:5001/remote")
                .Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _hubConnection.StartAsync();
            _logger.LogInformation("SignalR Started.");

            _hubConnection.On<string>("ReceiveMessage", message =>
            {
                _logger.LogInformation("Received message: {Message}", message);
            });

            _hubConnection.On<string>("RemoteCommand", command =>
            {
                if (false == string.IsNullOrWhiteSpace(command))
                {
                    _logger.LogInformation($"Remote Command : {command}");
                    Process.Start(new ProcessStartInfo
                    {
                        Arguments = "",
                        UseShellExecute = true,
                        FileName = "",
                    });
                }
            });

            while (!stoppingToken.IsCancellationRequested)
            {
                await _hubConnection.SendAsync("SendMessage", "Hello from Worker Service");

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
