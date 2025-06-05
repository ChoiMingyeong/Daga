using System.Numerics;

namespace DagaBlazorEngine.Models
{
    public abstract class DagaObject
    {
        public Vector2 Position { get; set; } = Vector2.Zero;

        public Vector2 Scale { get; set; } = Vector2.Zero;
    }
}
