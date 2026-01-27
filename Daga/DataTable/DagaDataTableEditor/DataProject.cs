namespace DagaDataTableEditor
{
    public class DataProject : BaseEntity
    {
        public Dictionary<ID, DataTable> Tables { get; set; } = [];
    }
}
