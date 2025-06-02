using DagaBlazorLibrary.Models;

namespace DagaBlazorLibrary.Engines
{
    public class DagaEngine : IAsyncDisposable
    {
        private readonly RenderEngine _renderEngine;

        public List<DagaObject> DagaObjects { get; } = [];

        public DagaEngine(RenderEngine renderEngine)
        {
            _renderEngine = renderEngine;
        }

        public void Initialize()
        {
            _renderEngine.Initialize();
        }

        public async Task InitializeAsync()
        {

        }

        public async Task OnFirstRenderAsync()
        {
            await _renderEngine.InitializeAsync();
        }

        public async Task UpdateAsync()
        {
            await Parallel.ForEachAsync(DagaObjects, async (dagaObject, _) =>
            {
                if (dagaObject.RenderTarget != null)
                {
                    await dagaObject.UpdateAsync();
                }
            });
        }

        public async Task DrawAsync()
        {
            await _renderEngine.DrawAsync(DagaObjects.Where(p => null != p.RenderTarget).Select(p => p.RenderTarget!));
        }

        public async ValueTask DisposeAsync()
        {
            await _renderEngine.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
