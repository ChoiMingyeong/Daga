namespace DagaDataGenerator.SrcGenerator;

public interface ISrcGenerator : IDisposable
{
    public bool TryAddEntity(params object?[]? objects);

    public bool ToSource(string filePath, string fileName);
}