using DagaBlazorEngine.Models;
using Microsoft.JSInterop;

namespace DagaBlazorEngine.Renderers
{

    public abstract class IRenderer(in IJSObjectReference canvasModule) : DagaObject
    {
        protected readonly IJSObjectReference _canvasModule = canvasModule;

        public abstract Task DrawAsync();
    }
}
