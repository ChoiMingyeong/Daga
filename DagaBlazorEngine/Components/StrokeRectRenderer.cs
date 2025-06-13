using Microsoft.JSInterop;

namespace DagaBlazorEngine.Components
{
    public class StrokeRectRenderer(in IJSObjectReference canvasModule) : IRenderer(canvasModule)
    {
        public override async Task DrawAsync()
        {
            var x = Transform.Position.X - Transform.Scale.X * 0.5f;
            var y = Transform.Position.Y - Transform.Scale.Y * 0.5f;
            await _canvasModule.InvokeVoidAsync("drawStrokeRect",x, y, Transform.Scale.X, Transform.Scale.Y, "green");
        }
    }
}
