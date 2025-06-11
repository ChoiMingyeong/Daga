using DagaBlazorEngine.Renderers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;

namespace DagaBlazorEngine.Services
{
    public class DagaRenderService
    {
        private readonly IJSRuntime _jsRuntime;

        private IJSObjectReference? _canvasModule;
        private List<IRenderer> _renderers = [];

        public DagaRenderService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync(ElementReference canvasRef)
        {
            _canvasModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/DagaBlazorEngine/js/canvas.js");
            await _canvasModule.InvokeVoidAsync("init", canvasRef);

            _renderers.Add(new CircleColliderRenderer(_canvasModule) { Position = new(50, 50), Scale = new(50, 0) });
            _renderers.Add(new RectColliderRenderer(_canvasModule) { Position = new(50, 25), Scale = new(100, 50) });
        }

        [MemberNotNull(nameof(_canvasModule))]
        private void ThrowIfNotInitialized()
        {
            if (_canvasModule is null)
            {
                throw new InvalidOperationException("DagaRenderService is not initialized. Call InitializeAsync first.");
            }
        }

        private async Task DrawBeginAsync()
        {
            ThrowIfNotInitialized();

            await _canvasModule.InvokeVoidAsync("drawBegin");
        }

        private async Task DrawEndAsync()
        {
            ThrowIfNotInitialized();

            await _canvasModule.InvokeVoidAsync("drawEnd");
        }

        public async Task UpdateAsync()
        {
            ThrowIfNotInitialized();

            await DrawBeginAsync();
            foreach (var renderer in _renderers)
            {
                await renderer.DrawAsync();
            }
            await DrawEndAsync();
        }
    }
}
