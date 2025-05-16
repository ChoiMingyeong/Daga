using TSID.Creator.NET;

namespace DagaEngine.Managers
{
    public class DagaGameObjectManager : DagaManager<DagaGameObject>
    {
        public List<DagaGameObject> GameObjects => [.. _objects.Values];

        private IEnumerable<DagaGameObject> EnableGameObjects => _objects.Values.Where(p => false == p.Disable);

        public override async Task InitializeAsync()
        {
            await Parallel.ForEachAsync(EnableGameObjects, async (obj, _) =>
            {
                await obj.InitializeAsync();
            });
        }

        public override async Task StartAsync()
        {
            await Parallel.ForEachAsync(EnableGameObjects, async (obj, _) =>
            {
                await obj.StartAsync();
            });
        }

        public override async Task UpdateAsync()
        {
            await Parallel.ForEachAsync(EnableGameObjects, async (obj, _) =>
            {
                await obj.UpdateAsync();
            });
        }

        public void Stop()
        {
            // Clean up resources
            foreach (var obj in _objects.Values)
            {
                obj.Stop();
            }
        }

        public void AddGameObject(DagaGameObject gameObject)
        {
            _objects.TryAdd(gameObject.ID, gameObject);
        }

        public void RemoveGameObject(DagaGameObject gameObject)
        {
            _objects.Remove(gameObject.ID);
        }

        public void RemoveGameObject(Tsid gameObjectID)
        {
            _objects.Remove(gameObjectID);
        }
    }
}
