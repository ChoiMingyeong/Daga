using DagaBlazorLibrary.Models;
using Microsoft.JSInterop;
using System.Numerics;

namespace DagaBlazorLibrary.Services
{
    public class ScreenSizeService : IAsyncDisposable
    {
        private readonly IJSRuntime _js;
        private DotNetObjectReference<ScreenSizeService>? _objRef;
        public event EventHandler<Vector2>? OnResizeHandler;

        public ScreenSizeService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<Vector2> GetCurrentSizeAsync()
        {
            return await _js.InvokeAsync<Vector2>("screenHelper.getDimensions");
        }

        public async Task InitializeAsync()
        {
            _objRef = DotNetObjectReference.Create(this);
            await _js.InvokeVoidAsync("screenHelper.registerResizeCallback", _objRef);
        }

        [JSInvokable]
        public void OnResize(Vector2 screen)
        {
            OnResizeHandler?.Invoke(this, screen);
        }

        public ValueTask DisposeAsync()
        {
            _objRef?.Dispose();
            return ValueTask.CompletedTask;
        }
    }
}
