namespace DagaBlazorEngine.Renderers
{
    public interface IRenderer
    {
       //W public bool IsVisible { get; set; }

        Task PreloadAsync();

        Task DrawAsync();
    }
}
