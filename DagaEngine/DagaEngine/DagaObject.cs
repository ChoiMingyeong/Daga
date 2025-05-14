using TSID.Creator.NET;

namespace DagaEngine
{

    public class DagaObject
    {
        public Tsid ID { get; init; } = TsidCreator.GetTsid();

        public string Name { get; set; } = string.Empty;

        public DagaObject()
        {
            
        }

        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task StartAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
