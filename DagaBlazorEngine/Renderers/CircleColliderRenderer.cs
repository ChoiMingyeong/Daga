using Microsoft.JSInterop;

namespace DagaBlazorEngine.Renderers
{

    public class CircleColliderRenderer(in IJSObjectReference canvasModule) : IRenderer(canvasModule)
    {
        public override async Task DrawAsync()
        {
            await _canvasModule.InvokeVoidAsync("drawStrokeCircle", Position.X, Position.Y, Scale.X, "green");
        }
    }
}
