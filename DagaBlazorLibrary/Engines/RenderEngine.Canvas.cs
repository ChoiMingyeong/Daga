using DagaBlazorLibrary.Attributes;
using DagaBlazorLibrary.Models;
using Microsoft.JSInterop;
using System.Diagnostics;

namespace DagaBlazorLibrary.Engines
{
    public partial class RenderEngine
    {
        private static IJSObjectReference? _canvasModule;
        private HashSet<IRenderTarget> _renderTargets = [];

        [AsyncInitialize]
        private async Task InitializeCanvasAsync()
        {
            _screenModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/DagaBlazorLibrary/js/canvasHelper.js");
            await _screenModule.InvokeVoidAsync("init");
            OnResizeHandler += async (_, screen) =>
            {
                await DrawAsync(_renderTargets);
            };
        }

        [AsyncDisposable]
        private ValueTask DisposeCanvasAsync()
        {
            return ValueTask.CompletedTask;
        }

        public static async Task DrawRectangle(float x, float y, int width, int height, string color = "black")
        {
            Debug.Assert(_canvasModule != null, "Canvas module is not initialized. Call InitializeCanvasAsync first.");
            await _canvasModule.InvokeVoidAsync("drawRectangle", x, y, width, height, color);
        }

        public async Task DrawAsync(IEnumerable<IRenderTarget> renderTargets)
        {
            var screenSize = await GetCurrentSizeAsync();
            await Parallel.ForEachAsync(renderTargets, async (target, _) =>
            {
                await target.DrawAsync(screenSize);
            });
        }
    }
}
