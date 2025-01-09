namespace DagaDataGenerator.SrcGenerator;

public interface ISrcGenerator : IDisposable
{
    public string Namespace { get; set; }

    public bool TryAddEntity(params object?[]? objects);

    public bool CreateSource(params string[] strs);
}