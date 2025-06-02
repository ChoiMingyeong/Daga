using System.Numerics;

namespace DagaBlazorLibrary.Models
{
    public class Transform
    {
        public Vector2 Position { get; set; } = new Vector2(0f, 0f);

        public Vector2 Scale { get; set; } = new Vector2(1f, 1f);
    }
}
