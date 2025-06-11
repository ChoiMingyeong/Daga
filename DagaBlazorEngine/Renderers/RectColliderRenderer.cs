using Microsoft.JSInterop;

namespace DagaBlazorEngine.Renderers
{

    public class RectColliderRenderer(in IJSObjectReference canvasModule) : IRenderer(canvasModule)
    {
        public override async Task DrawAsync()
        {
            await _canvasModule.InvokeVoidAsync("drawStrokeRect", Position.X - (Scale.X * 0.5f), Position.Y - (Scale.Y * 0.5f), Scale.X, Scale.Y, "green");
        }
    }
}
