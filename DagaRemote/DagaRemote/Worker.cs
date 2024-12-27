using DagaCommon.Enums;
using DagaRemote.Hub;
using Microsoft.AspNetCore.SignalR.Client;
using System.Diagnostics;

namespace DagaRemote
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly List<Process> _processes = new();

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var exePaths = _configuration.GetSection("ExecutablePaths").Get<List<string>>();

            if (exePaths == null || exePaths.Count == 0)
            {
                _logger.LogError("No executable paths are configured.");
                return;
            }

            _logger.LogInformation("Starting executables...");

            foreach (var exePath in exePaths)
            {
                try
                {
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = exePath,
                            UseShellExecute = true,
                            CreateNoWindow = false,
                        }
                    };

                    process.Start();
                    _processes.Add(process);
                    _logger.LogInformation($"Started: {exePath}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Failed to start executable: {exePath}");
                }
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Stopping the worker...");
            StopExecutables();
            await base.StopAsync(stoppingToken);
        }

        private void StopExecutables()
        {
            foreach (var process in _processes)
            {
                if (process != null && !process.HasExited)
                {
                    try
                    {
                        _logger.LogInformation($"Stopping: {process.StartInfo.FileName}");
                        process.Kill(true);
                        process.WaitForExit();
                        _logger.LogInformation($"Stopped: {process.StartInfo.FileName}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Failed to stop: {process.StartInfo.FileName}");
                    }
                }
            }

            _processes.Clear();
        }
    }
}
