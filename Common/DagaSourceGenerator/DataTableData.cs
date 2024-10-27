namespace DagaSourceGenerator
{
    public class DataTableData : IDataTempltate
    {
        public Namespace Namespace { get; set; } = Namespace.Default;

        public required ClassName ClassName { get; set; } = "DataTable";
    }
}
