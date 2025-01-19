namespace DagaDataGenerator.SrcGenerator.DataTable;

public class IDataTable(string name, string? summary = null, params DataTableEntity[] entities)
    : ISrc<DataTableEntity>(name, summary, entities)
{
    private uint _createID = 1;
    public uint CreateID { get
        {
            return Interlocked.Increment(ref _createID);
        } 
    }
    public bool TryAddEntities(string typeName, string name, string value)
    {


        return true;
    }
}
