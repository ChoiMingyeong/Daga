using DataTableEditor.Core;

namespace DataTableEditor
{
    public class DataTable
    {

    }

    public class DataCell
    {
        public ID ColumnID { get; set; }

        public ID RowID { get; set; }

        public string Value { get; set; } = string.Empty;
    }
}
