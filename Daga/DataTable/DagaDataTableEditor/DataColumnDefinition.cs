namespace DagaDataTableEditor
{
    public class DataColumnDefinition : BaseEntity<DataColumnDefinition>
    {
        public required Type DataType { get; set; }

        public bool IsUnsigned { get; set; } = false;

        public bool IsNullable { get; set; } = false;

        public string? DefaultValue { get; set; }
    }
}
