namespace DagaDataGenerator.SrcGenerator.Const;

public class ConstSrcGenerator : ISrcGenerator
{
    public bool CreateSource()
    {
        throw new NotImplementedException();
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