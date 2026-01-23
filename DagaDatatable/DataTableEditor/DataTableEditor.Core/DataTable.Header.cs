namespace DataTableEditor.Core
{
    public partial class DataTable
    {
        public partial class Header
        {
            public string Name { get; set; } = string.Empty;

            public DataType Type { get; set; } = DataType.Int;

            public bool Nullable { get; set; } = false;

            public string DefaultValue { get; set; } = string.Empty;
        }

    }

}
