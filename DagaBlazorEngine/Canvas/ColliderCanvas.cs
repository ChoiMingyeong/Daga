using DagaBlazorEngine.Renderers;

namespace DagaBlazorEngine.Canvas
{
    internal class ColliderCanvas : ICanvas<IColliderRenderer>
    {
        public CancellationTokenSource CancellationTokenSource { get; } = new();

        public Task InitializeAsync()
        {
            CancellationTokenSource.TryReset();
            return Task.CompletedTask;
        }

        public async Task DrawAsync(IEnumerable<IColliderRenderer> renderers)
        {
            await Parallel.ForEachAsync(renderers, async (renderer, CancellationTokenSource) =>
            {
                await renderer.DrawAsync();
            });
        }
    }
}
