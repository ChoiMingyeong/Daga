using DagaBlazorEngine.Models;
using Microsoft.JSInterop;

namespace DagaBlazorEngine.Components
{

    public abstract class IRenderer(in IJSObjectReference canvasModule) : IComponent
    {
        public Transform Transform { get; set; } = default!;

        public bool Active { get; set; } = true;

        protected readonly IJSObjectReference _canvasModule = canvasModule;

        public abstract Task DrawAsync();
    }
}
