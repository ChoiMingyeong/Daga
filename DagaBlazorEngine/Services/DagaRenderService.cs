using DagaBlazorEngine.Components;
using DagaBlazorEngine.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Numerics;

namespace DagaBlazorEngine.Services
{
    public class DagaRenderService
    {
        private readonly IJSRuntime _jsRuntime;

        private IJSObjectReference? _canvasModule;
        private List<DagaObject> _dagaObjects = [];

        public DagaRenderService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeAsync(ElementReference canvasRef)
        {
            _canvasModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/DagaBlazorEngine/js/webgl.js");
            await _canvasModule.InvokeVoidAsync("init", canvasRef);

            //DagaObject circle = new();
            //circle.Transform.Position = new Vector2(50, 50);
            //circle.Transform.Scale = new Vector2(50, 50);
            //circle.AddComponents(new StrokeCircleRenderer(_canvasModule));
            //_dagaObjects.Add(circle);

            //DagaObject rect = new();
            //rect.Transform.Position = new Vector2(200, 50);
            //rect.Transform.Scale = new Vector2(100, 50);
            //rect.AddComponents(new StrokeRectRenderer(_canvasModule));
            //_dagaObjects.Add(rect);
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

            //await _canvasModule.InvokeVoidAsync("drawEnd");
        }

        public async Task UpdateAsync()
        {
            ThrowIfNotInitialized();

            await DrawBeginAsync();
            foreach (var renderer in _dagaObjects
                .Where(p=>p.Active && p.Visible)
                .SelectMany(p => p.Components.OfType<IRenderer>()).Where(p=>p.Active))
            {
                await renderer.DrawAsync();
            }
            await DrawEndAsync();
        }

        public async Task<List<PointF>> GetOutline(string url, int threshold = 10)
        {
            ThrowIfNotInitialized();

            var rawPoints = await _canvasModule.InvokeAsync<List<List<double>>>("traceImageOutline", url, threshold);
            var outline = rawPoints.Where(p => p.Count >= 2).Select(p => new PointF((float)p[0], (float)p[1])).ToList();

            return outline;
        }
    }
}
