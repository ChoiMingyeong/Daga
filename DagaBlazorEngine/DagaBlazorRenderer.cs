using Microsoft.JSInterop;

namespace DagaBlazorEngine
{
    public class DagaBlazorRenderer
    {
        private readonly IJSRuntime _jsRuntime;

        public DagaBlazorRenderer(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
