namespace DagaDataGenerator.SrcGenerator.DataTable;

public class IDataTable(string name, string? summary = null, params DataTableEntity[] entities)
    : ISrc<DataTableEntity>(name, summary, entities)
{
    public readonly uint DataTableID = dataTableID;

}
