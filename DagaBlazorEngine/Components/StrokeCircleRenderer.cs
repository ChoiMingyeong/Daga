using Microsoft.JSInterop;

namespace DagaBlazorEngine.Components
{

    public class StrokeCircleRenderer(in IJSObjectReference canvasModule) : IRenderer(canvasModule)
    {
        public override async Task DrawAsync()
        {
            await _canvasModule.InvokeVoidAsync("drawStrokeCircle", Transform.Position.X, Transform.Position.Y, Transform.Scale.X, "green");
        }
    }
}
