namespace DagaDataGenerator.SrcGenerator.DataSet;

public class DataSetSrcGenerator : ISrcGenerator
{
    public bool AddEntity()
    {
        throw new NotImplementedException();
    }

    public bool CreateSource()
    {
        return false;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}