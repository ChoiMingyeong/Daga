using DagaBlazorEngine.Attributes;
using DagaBlazorEngine.Renderers;
using Microsoft.JSInterop;

namespace DagaBlazorEngine.Helpers
{
    [JSHelper("/_content/DagaBlazorEngine/js/canvasHelper.js")]
    public class CanvasHelper(in IJSRuntime jsRuntime) : IJSHelper(jsRuntime)
    {
        private Task PreloadFrameAsync()
        {
            throw new NotImplementedException();

        }

        private Task DrawFrameAsync()
        {
            throw new NotImplementedException();

        }

        private Task DrawColliderAsync()
        {
            throw new NotImplementedException();
        }

        private Task DrawUIAsync()
        {

            throw new NotImplementedException();
        }

        public async Task DrawAsync(IEnumerable<IRenderer> renderers)
        {
            foreach (var renderer in renderers)
            {
            }

            await PreloadFrameAsync();
            await DrawFrameAsync();
            await DrawColliderAsync();
            await DrawUIAsync();
        }
    }
}
