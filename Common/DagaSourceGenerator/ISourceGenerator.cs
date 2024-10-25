namespace DagaSourceGenerator
{
    public interface ISourceGenerator<T> where T : IDataTempltate
    {
        public void Initialize(IEnumerable<T> data);

        public void Generate();
    }
}
