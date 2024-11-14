namespace DagaSourceGenerator
{
    internal interface ISourceBase<T>
    {
        public UID UID { get; }

        public string Name { get; }

        public T Value { get; }
    }
}
