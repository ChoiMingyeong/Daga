namespace DagaDataGenerator.SrcGenerator.DataSet;

public class DataSetSrcGenerator : ISrcGenerator
{
    public bool CreateSource()
    {
        return false;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public bool TryAddEntity(params object?[]? objects)
    {
        throw new NotImplementedException();
    }
}