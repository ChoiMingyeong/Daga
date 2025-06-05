using DagaBlazorEngine.Renderers;

namespace DagaBlazorEngine.Canvas
{
    internal class UICanvas : ICanvas<IUIRenderer>
    {
        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task DrawAsync(IEnumerable<IUIRenderer> renderers)
        {
            throw new NotImplementedException();
        }
    }
}
