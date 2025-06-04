using DagaBlazorEngine.Helpers;
using Microsoft.JSInterop;

namespace DagaBlazorEngine.Renderers
{
    public class DagaBlazorGraphicEngine
    {
        private readonly IJSRuntime _jsRuntime;

        private readonly ScreenHelper _screenHelper;
        private readonly CanvasHelper _canvasHelper;

        public DagaBlazorGraphicEngine(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;

            _screenHelper = new ScreenHelper(_jsRuntime);
            _canvasHelper = new CanvasHelper(_jsRuntime);

            _screenHelper.OnResizeHandler += async (_, screen) =>
            {
                await _canvasHelper.DrawAsync([]);
            };
        }

        public async Task InitializeAsync()
        {
            await _screenHelper.InitializeAsync();
            await _canvasHelper.InitializeAsync();
        }

        private async Task UpdateAsync()
        {
            await _canvasHelper.DrawAsync([]);
        }
    }
}
