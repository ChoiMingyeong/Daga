using DagaBlazorLibrary.Attributes;
using Microsoft.JSInterop;
using System.Diagnostics;
using System.Numerics;

namespace DagaBlazorLibrary.Engines
{

    public partial class RenderEngine
    {
        private IJSObjectReference? _screenModule;
        public event EventHandler<Vector2>? OnResizeHandler;

        [AsyncInitialize]
        private async Task InitializeScreenSizeAsync()
        {
            _screenModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/DagaBlazorLibrary/js/screenHelper.js");
            await _screenModule.InvokeVoidAsync("registerResizeCallback", DotNetObjectReference.Create(this));
        }

        [AsyncDisposable]
        private ValueTask DisposeScreenSizeAsync()
        {
            OnResizeHandler = null;
            return ValueTask.CompletedTask;
        }

        public async Task<Vector2> GetCurrentSizeAsync()
        {
            Debug.Assert(_screenModule != null, "Screen module is not initialized. Call InitializeAsync first.");

            return await _screenModule.InvokeAsync<Vector2>("getDimensions");
        }

        [JSInvokable]
        public void OnResize(Vector2 screen)
        {
            OnResizeHandler?.Invoke(this, screen);
        }
    }
}
