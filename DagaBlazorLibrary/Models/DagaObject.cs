namespace DagaBlazorLibrary.Models
{
    public class DagaObject : Transform
    {
        public IRenderTarget? RenderTarget { get; set; } = null;

        public virtual Task UpdateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
