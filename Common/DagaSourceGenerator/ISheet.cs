namespace DagaSourceGenerator
{
    public interface ISheet<T> where T : ISheetLine
    {
        public Namespace Namespace { get; init; }

        public string Name { get; init; }

        public List<T> Values { get; init; }
    }
}
