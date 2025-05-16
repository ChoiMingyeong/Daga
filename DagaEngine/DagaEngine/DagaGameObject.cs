using System.Numerics;

namespace DagaEngine
{
    public class DagaGameObject : DagaObject
    {
        public Vector3 Position = new Vector3(0, 0, 0);

        public Vector3 Rotation = new Vector3(0, 0, 0);

        public Vector3 Scale = new Vector3(1, 1, 1);

        public byte Layer = 0;

        public int Order = 0;

        public bool Disable = false;

        public bool Visible = true;

        public List<DagaComponent> Components { get; private set; } = [];

        public DagaGameObject()
        {
        }

        public override async Task InitializeAsync()
        {
            await Parallel.ForEachAsync(Components, async (component, _) =>
            {
                await component.InitializeAsync();
            });
        }

        public override async Task StartAsync()
        {
            await Parallel.ForEachAsync(Components, async (component, _) =>
            {
                await component.StartAsync();
            });
        }

        public override async Task UpdateAsync()
        {
            await Parallel.ForEachAsync(Components, async (component, _) =>
            {
                await component.UpdateAsync();
            });
        }

        public void Stop()
        {
            foreach (var component in Components)
            {
                component.Stop();
            }
        }

        public void AddComponent(DagaComponent component)
        {
            Components.Add(component);
        }

        public void RemoveComponent(DagaComponent component)
        {
            Components.Remove(component);
        }
    }
}
