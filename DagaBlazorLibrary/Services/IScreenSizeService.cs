using DagaBlazorLibrary.Models;

namespace DagaBlazorLibrary.Services
{
    public interface IScreenSizeService
    {
        event EventHandler<ScreenDimensions>? OnResizeHandler;
        Task<ScreenDimensions> GetCurrentSizeAsync();
        Task InitializeAsync();
    }
}
