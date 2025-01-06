namespace DagaDataGenerator.SrcGenerator;

public interface ISrcGenerator : IDisposable
{
    public bool TryAddEntity(params object?[]? objects);

    public bool CreateSource(string filePath, string fileName);
}