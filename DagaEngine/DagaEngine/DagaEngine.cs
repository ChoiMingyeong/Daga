namespace DagaEngine
{
    public sealed class DagaEngine
    {
        private readonly List<DagaManager> dagaManagers = [];

        private bool isRunning;

        public DagaEngine()
        {
            // Initialize the engine

        }

        public async Task InitializeAsync()
        {
            await Parallel.ForEachAsync(dagaManagers, async (manager, _) =>
            {
                // Update each manager
                await manager.InitializeAsync();
            });
        }

        public async Task RunAsync()
        {
            // Initialize the engine
            await InitializeAsync();

            // Main loop
            isRunning = true;
            while (isRunning)
            {
                // Update the engine
                await UpdateAsync();
            }
        }

        private async Task UpdateAsync()
        {
            await Parallel.ForEachAsync(dagaManagers, async (manager, _) =>
            {
                // Update each manager
                await manager.UpdateAsync();
            });
        }

        public void Shutdown()
        {
            // Clean up resources
            isRunning = false;
        }
    }
}
