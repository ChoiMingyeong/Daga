namespace DagaDataTableEditor
{
    public abstract class BaseEntity<T>
    {
        public Id<T> Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
