using DagaBlazorEngine.Models;
using Microsoft.JSInterop;

namespace DagaBlazorEngine.Services
{
    public class ScreenSizeService
    {
        public event EventHandler<ScreenSize>? ResizeHandler;
        public float Width { get; private set; }
        public float Height { get; private set; }

        private readonly JSRuntime _jsRuntime;
        private IJSObjectReference? _module;

        public ScreenSizeService(JSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync()
        {
            _module ??= await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/DagaBlazorEngine/js/screenSizeModule.js");
            if(null == _module)
            {
                throw new InvalidOperationException("Failed to load screen size module.");
            }

            if (await _module.InvokeAsync<ScreenSize>("getScreenSize") is ScreenSize screenSize)
            {
                Width = screenSize.X;
                Height = screenSize.Y;
            }
        }

        [JSInvokable]
        public void OnResize(ScreenSize screenSize)
        {
            Width = screenSize.X;
            Height = screenSize.Y;
            ResizeHandler?.Invoke(null, screenSize);
        }
    }
}
