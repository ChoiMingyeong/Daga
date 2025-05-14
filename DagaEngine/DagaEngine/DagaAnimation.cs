namespace DagaEngine
{
    public class DagaAnimation : DagaComponent
    {
        public DagaAnimation()
        {
        }

        public float Speed { get; set; } = 1.0f;

        public bool Loop { get; set; } = false;
    }
}
