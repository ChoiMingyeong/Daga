using DagaBlazorEngine.Components;

namespace DagaBlazorEngine.Models
{
    public class DagaObject
    {
        public DagaObject? Parent { get; set; } = null;

        public bool Visible { get; set; } = true;

        public bool Active { get; set; } = true;

        public Transform Transform { get; set; } = new Transform();

        private List<IComponent> _components = [];
        public List<IComponent> Components
        {
            get => [.. _components, Transform];
        }

        public DagaObject()
        {
            Transform.Parent = this;
        }

        public void AddComponents(params IComponent[] components)
        {
            foreach (var component in components)
            {
                component.Transform = this.Transform;
                _components.Add(component);
            }
        }
    }
}
