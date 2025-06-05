using DagaBlazorEngine.Renderers;

namespace DagaBlazorEngine.Canvas
{
    internal interface ICanvas<T> where T : IRenderer
    {
        public Task InitializeAsync();

        public Task DrawAsync(IEnumerable<T> renderers);
    }
}
