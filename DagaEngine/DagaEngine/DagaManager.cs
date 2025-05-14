using TSID.Creator.NET;

namespace DagaEngine
{
    public interface IDagaManager
    {
        Task InitializeAsync();
        Task StartAsync();
        Task UpdateAsync();
    }

    public abstract class DagaManager<T> : DagaObject, IDagaManager
        where T : DagaObject
    {
        protected Dictionary<Tsid, T> _objects = [];

        public DagaManager()
        {
        }

        public override async Task InitializeAsync()
        {
            await Parallel.ForEachAsync(_objects.Values, async (obj, _) =>
            {
                await obj.InitializeAsync();
            });
        }

        public override async Task StartAsync()
        {
            await Parallel.ForEachAsync(_objects.Values, async (obj, _) =>
            {
                await obj.StartAsync();
            });
        }

        public override async Task UpdateAsync()
        {
            await Parallel.ForEachAsync(_objects.Values, async (obj, _) =>
            {
                await obj.UpdateAsync();
            });
        }

        public void AddObject(T obj)
        {
            _objects.TryAdd(obj.ID, obj);
        }

        public void RemoveObject(Tsid id)
        {
            _objects.Remove(id);
        }

        public void RemoveObject(T obj)
        {
            _objects.Remove(obj.ID);
        }
    }
}
