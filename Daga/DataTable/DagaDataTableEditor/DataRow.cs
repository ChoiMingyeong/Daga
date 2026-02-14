namespace DagaDataTableEditor
{
    public class DataRow : BaseEntity<DataRow>
    {
        public List<DataCell> Cells { get; set; } = [];
    }
}
