namespace DagaEngine
{
    public sealed class DagaEngine : Singleton<DagaEngine>
    {
        public readonly DagaSceneManager SceneManager = new();

        private bool _isRunning = false;

        public DagaEngine()
        {
            // Initialize the engine

        }

        public async Task InitializeAsync()
        {
            await SceneManager.InitializeAsync();
        }

        public async Task RunAsync()
        {
            // Main loop
            _isRunning = true;
            while (_isRunning)
            {
                DagaTime.Update();

                // Update the engine
                await SceneManager.UpdateAsync();
            }
        }

        public void Stop()
        {
            // Clean up resources
            _isRunning = false;
        }
    }
}
