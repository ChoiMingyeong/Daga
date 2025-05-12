using System.Collections.Concurrent;
using TSID.Creator.NET;

namespace DagaEngine
{
    public class DagaObjectManager : DagaManager
    {
        private ConcurrentDictionary<Tsid, DagaObject> objects = [];

        public DagaObjectManager()
        {

        }

        public sealed override async Task InitializeAsync()
        {
            await Parallel.ForEachAsync(objects.Values, async (obj, _) =>
            {
                await obj.InitializeAsync();
            });
        }

        public sealed override async Task UpdateAsync()
        {
            await Parallel.ForEachAsync(objects.Values, async (obj, _) =>
            {
                await obj.UpdateAsync();
            });
        }
    }
}
