using DagaEngine.Managers;

namespace DagaEngine
{
    public sealed class DagaEngine : Singleton<DagaEngine>
    {
        public readonly HashSet<IDagaManager> Managers = [];
        public DagaNetworkManager NetworkMgr => (DagaNetworkManager)Managers.Single(m => m is DagaNetworkManager);
        public DagaSceneManager SceneMgr => (DagaSceneManager)Managers.Single(m => m is DagaSceneManager);

        private bool _isRunning = false;

        public DagaEngine()
        {
            // Initialize the engine
            Managers.Add(new DagaNetworkManager());
            Managers.Add(new DagaSceneManager());
        }

        public async Task InitializeAsync()
        {
            await NetworkMgr.InitializeAsync();
            await SceneMgr.InitializeAsync();
        }

        public async Task RunAsync()
        {
            // Main loop
            _isRunning = true;
            while (_isRunning)
            {
                DagaTime.Update();

                // Update the engine
                await NetworkMgr.UpdateAsync();
                await SceneMgr.UpdateAsync();
            }
        }

        public async Task Stop()
        {
            // Clean up resources
            _isRunning = false;

            await NetworkMgr.StopAsync();
            await SceneMgr.StopAsync();
        }
    }
}
