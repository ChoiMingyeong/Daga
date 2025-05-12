namespace DagaEngine
{
    public abstract class DagaManager
    {
        public abstract Task InitializeAsync();

        public abstract Task UpdateAsync();
    }
}
