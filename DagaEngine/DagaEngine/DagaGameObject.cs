namespace DagaEngine
{
    public sealed class DagaGameObject : DagaObject
    {
        public bool Disable { get; set; } = false;

        public bool Visible { get; set; } = true;

        public List<DagaComponent> Components { get; private set; } = [];

        public DagaGameObject()
        {
        }

        public override sealed async Task InitializeAsync()
        {
            await Parallel.ForEachAsync(Components, async (component, _) =>
            {
                await component.InitializeAsync();
            });
        }

        public override sealed async Task StartAsync()
        {
            await Parallel.ForEachAsync(Components, async (component, _) =>
            {
                await component.StartAsync();
            });
        }

        public override sealed async Task UpdateAsync()
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
