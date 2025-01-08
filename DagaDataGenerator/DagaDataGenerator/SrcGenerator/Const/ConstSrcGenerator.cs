namespace DagaDataGenerator.SrcGenerator.Const;

public class ConstSrcGenerator(string @namespace) : ISrcGenerator
{
    public string Namespace { get; set; } = @namespace;

    public Dictionary<string, IConstant> Constants { get; private set; } = [];

    public bool TryAddEntity(params object?[]? objects)
    {
        return true;
    }

    public bool CreateSource(string filePath, string fileName)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}