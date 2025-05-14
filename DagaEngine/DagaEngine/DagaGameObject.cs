namespace DagaEngine
{
    public sealed class DagaGameObject : DagaObject
    {
        public List<DagaComponent> Components { get; } = [];

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
            // Clean up resources
            foreach (var component in Components)
            {
                component.Stop();
            }
        }
    }
}
