using Microsoft.JSInterop;

namespace DagaBlazorEngine.Components
{
    public class PolygonRenderer(in IJSObjectReference canvasModule) : IRenderer(canvasModule)
    {
        public override async Task DrawAsync()
        {
            await _canvasModule.InvokeVoidAsync("drawPolygon", Transform.Position.X, Transform.Position.Y, Transform.Scale.X, "green");
        }
    }
}
