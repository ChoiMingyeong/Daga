using TSID.Creator.NET;

namespace DagaEngine
{
    public class DagaSceneManager : DagaManager<DagaScene>
    {
        public readonly DagaGameObjectManager GlobalGameObjectManager = new();

        public DagaScene? NowScene { get; private set; } = null;

        public override async Task InitializeAsync()
        {
            await GlobalGameObjectManager.InitializeAsync();
            if(null != NowScene)
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
