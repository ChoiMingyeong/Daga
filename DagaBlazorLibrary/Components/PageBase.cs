using DagaBlazorLibrary.Engines;
using Microsoft.AspNetCore.Components;

namespace DagaBlazorLibrary.Components
{
    public class PageBase : ComponentBase, IAsyncDisposable
    {
        [Inject] 
        protected DagaEngine DagaEngine { get; set; } = null!;

        private long _canvasId = 0;
        protected string CanvasId => _canvasId.ToString();

        public PageBase()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await DagaEngine.InitializeAsync();
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await DagaEngine.OnFirstRenderAsync();
            }
            else
            {
                await DagaEngine.DrawAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DagaEngine.DisposeAsync();
        }

        public async Task UpdateAsync()
        {
            await DagaEngine.UpdateAsync();
        }
    }
}
