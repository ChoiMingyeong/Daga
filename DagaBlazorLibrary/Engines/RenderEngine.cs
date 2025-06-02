using DagaBlazorLibrary.Cache;
using Microsoft.JSInterop;

namespace DagaBlazorLibrary.Engines
{
    public partial class RenderEngine : IAsyncDisposable
    {
        private readonly IJSRuntime _jsRuntime;

        public RenderEngine(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public void Initialize()
        {
            MethodCache.Initialize(this);
        }

        public async Task InitializeAsync()
        {
            await MethodCache.InitializeAsync(this);
        }

        public async ValueTask DisposeAsync()
        {
            await MethodCache.DisposeAsync(this);
            GC.SuppressFinalize(this);
        }
    }
}
