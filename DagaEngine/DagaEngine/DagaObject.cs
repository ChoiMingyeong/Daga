using TSID.Creator.NET;

namespace DagaEngine
{

    public class DagaObject
    {
        public DagaObject()
        {
            
        }

        public Tsid ObjectID { get; init; } = TsidCreator.GetTsid();

        public string Name { get; set; } = string.Empty;

        public async Task InitializeAsync()
        {
            // Simulate some work
            await Task.Delay(100);
        }

        public async Task UpdateAsync()
        {
            // Simulate some work
            await Task.Delay(100);
        }
    }
}
