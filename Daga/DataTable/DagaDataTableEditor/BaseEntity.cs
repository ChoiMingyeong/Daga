namespace DagaDataTableEditor
{
    public abstract class BaseEntity
    {
        public ID ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
