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
}