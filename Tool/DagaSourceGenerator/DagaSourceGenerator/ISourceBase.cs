namespace DagaSourceGenerator
{
    public interface ISourceBase
    {
        public Uid Uid { get; init; }
    }

    public interface IHeader
    {
        public string PropertyName { get; set; }

        public Type PropertyType { get; set; }
    }
}
