namespace DagaEngine
{
    public class DagaScene : DagaObject
    {
        public readonly DagaGameObjectManager GameObjectManager = new();

        public DagaScene()
        {

        }

        public override async Task InitializeAsync()
        {
            await GameObjectManager.InitializeAsync();
        }

        public override async Task StartAsync()
        {
            await GameObjectManager.StartAsync();
        }

        public override async Task UpdateAsync()
        {
            await GameObjectManager.UpdateAsync();
        }

        public void Stop()
        {
            GameObjectManager.Stop();
        }
    }
}
