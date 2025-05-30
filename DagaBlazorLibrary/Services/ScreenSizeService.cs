using DagaBlazorLibrary.Models;
using Microsoft.JSInterop;

namespace DagaBlazorLibrary.Services
{
    public class ScreenSizeService : IScreenSizeService, IAsyncDisposable
    {
        private readonly IJSRuntime _js;
        private DotNetObjectReference<ScreenSizeService>? _objRef;
        public event EventHandler<ScreenDimensions>? OnResizeHandler;

        public ScreenSizeService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<ScreenDimensions> GetCurrentSizeAsync()
        {
            return await _js.InvokeAsync<ScreenDimensions>("screenHelper.getDimensions");
        }

        public async Task InitializeAsync()
        {
            _objRef = DotNetObjectReference.Create(this);
            await _js.InvokeVoidAsync("screenHelper.registerResizeCallback", _objRef);
        }

        [JSInvokable]
        public void OnResize(ScreenDimensions dimensions)
        {
            OnResizeHandler?.Invoke(this, dimensions);
        }

        public ValueTask DisposeAsync()
        {
            _objRef?.Dispose();
            return ValueTask.CompletedTask;
        }
    }
}
