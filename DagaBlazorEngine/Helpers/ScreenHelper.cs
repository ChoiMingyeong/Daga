using DagaBlazorEngine.Attributes;
using Microsoft.JSInterop;
using System.Numerics;

namespace DagaBlazorEngine.Helpers
{
    [JSHelper("/_content/DagaBlazorEngine/js/screenHelper.js")]
    public class ScreenHelper(in IJSRuntime jsRuntime) : IJSHelper(jsRuntime)
    {
        public event EventHandler<Vector2>? OnResizeHandler;

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            await Module!.InvokeVoidAsync("resizeCallback", DotNetObjectReference.Create(this));
        }

        public async Task<Vector2> GetCurrentSizeAsync()
        {
            if (Module == null)
            {
                throw new InvalidOperationException("ScreenHelper module is not initialized. Call InitializeAsync first.");
            }

            return await Module.InvokeAsync<Vector2>("getScreenSize");
        }

        [JSInvokable]
        public void OnResize(Vector2 screen)
        {
            OnResizeHandler?.Invoke(this, screen);
        }
    }
}
