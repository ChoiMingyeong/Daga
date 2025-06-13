using DagaBlazorEngine.Models;
using System.Numerics;
using System.Runtime.InteropServices;

namespace DagaBlazorEngine.Components
{
    public class Transform : IComponent
    {
        Transform IComponent.Transform { get; set; } = default!;

        public bool Active { get; set; } = true;

        public DagaObject? Parent { get; set; } = null;

        public Vector2 Position { get; set; } = Vector2.Zero;

        public Vector2 Scale { get; set; } = Vector2.One;
    }
}
