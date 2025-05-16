using TSID.Creator.NET;

namespace DagaEngine.Managers
{
    public class DagaSceneManager : DagaManager<DagaScene>
    {
        public readonly DagaGameObjectManager GlobalGameObjectManager = new();

        public DagaScene? NowScene { get; private set; } = null;

        public override async Task InitializeAsync()
        {
            await GlobalGameObjectManager.InitializeAsync();
            if (null != NowScene)
            {
                await NowScene.InitializeAsync();
            }
        }

        public override async Task StartAsync()
        {
            await GlobalGameObjectManager.StartAsync();
            if (null != NowScene)
            {
                await NowScene.StartAsync();
            }
        }

        public override async Task UpdateAsync()
        {
            await GlobalGameObjectManager.UpdateAsync();
            if (null != NowScene)
            {
                await NowScene.UpdateAsync();
            }
        }

        public void AddScene(DagaScene scene)
        {
            if(_objects.TryAdd(scene.ID, scene))
            {
                NowScene ??= scene;
            }
        }

        public void RemoveScene(Tsid sceneID)
        {
            if(NowScene?.ID == sceneID)
            {
                NowScene.Stop();
                NowScene = null;
            }

            _objects.Remove(sceneID);
        }

        public async Task ChangeScene(Tsid sceneID)
        {
            if (NowScene != null)
            {
                NowScene.Stop();
                NowScene = null;
            }

            if (_objects.TryGetValue(sceneID, out var scene))
            {
                NowScene = scene;
                await NowScene.StartAsync();
            }
        }
    }
}
