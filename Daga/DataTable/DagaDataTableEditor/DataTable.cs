namespace DagaDataTableEditor
{
    public class DataTable : BaseEntity
    {
        public List<DataColumnDefinition> ColumnDefinitions { get; set; } = [];

        public List<DataCell> Cells { get; set; } = [];

        public List<List<DataCell>> Rows => [.. Cells.GroupBy(cell => cell.RowID).Select(group => group.ToList())];
    }
}
