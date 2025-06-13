using DagaBlazorEngine.Models;

namespace DagaBlazorEngine.Components
{
    public interface IComponent
    {
        public bool Active { get; set; }

        public Transform Transform { get; set; }
    }
}
