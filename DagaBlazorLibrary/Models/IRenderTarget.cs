namespace DagaBlazorLibrary.Models
{
    public abstract class IRenderTarget : Transform
    {
        public abstract Task PreloadAsync();

        public abstract Task DrawAsync();
    }

    public class RectangleRenderTarget : IRenderTarget
    {
        public override Task PreloadAsync()
        {
            return Task.CompletedTask;
        }

        public async override Task DrawAsync()
        {

        }
    }
}
