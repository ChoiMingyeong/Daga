using Microsoft.JSInterop;

namespace DagaBlazorLibrary.Services
{
    public class CanvasHelperService
    {
        private readonly IJSRuntime _jsRuntime;

        public CanvasHelperService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitAsync(string canvasId)
        {
            await _jsRuntime.InvokeVoidAsync("canvasHelper.init", canvasId);
        }

        public async Task DrawRectAsync(double x, double y, double width, double height, string fillColor, string strokeColor)
        {
            await _jsRuntime.InvokeVoidAsync("canvasHelper.drawRect", x, y, width, height, fillColor, strokeColor);
        }
        public async Task DrawImageAsync(string imageUrl, double x, double y, double width, double height)
        {
            await _jsRuntime.InvokeVoidAsync("canvasHelper.drawImage", imageUrl, x, y, width, height);
        }

        public async Task ClearAsync()
        {
            await _jsRuntime.InvokeVoidAsync("canvasHelper.clear");
        }
    }

}
