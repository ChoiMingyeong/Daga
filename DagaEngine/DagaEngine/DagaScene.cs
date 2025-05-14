using System.Diagnostics;

namespace DagaEngine
{
    public class DagaScene : DagaObject
    {
        private DagaGameObjectManager _gameObjectManager = new();

        public DagaScene()
        {

        }

        public override async Task InitializeAsync()
        {
            await _gameObjectManager.InitializeAsync();
        }

        public override async Task StartAsync()
        {
            await _gameObjectManager.StartAsync();
        }

        public override async Task UpdateAsync()
        {
            await _gameObjectManager.UpdateAsync();
        }

        public void Stop()
        {
            _gameObjectManager.Stop();
        }
    }
}
