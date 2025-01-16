namespace DagaDataGenerator.SrcGenerator.DataTable;

public class DataTableSrcGenerator(string @namespace) : ISrcGenerator
{
    public string Namespace { get; set; } = @namespace;

    public Dictionary<string, IDataTable> DataTables { get; private set; } = [];


    public bool CreateSource(params string[] strs)
    {
        return true;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
