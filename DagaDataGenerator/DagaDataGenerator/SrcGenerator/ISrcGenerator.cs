namespace DagaDataGenerator.SrcGenerator;

public interface ISrcGenerator : IDisposable
{
    public string Namespace { get; set; }

    public bool CreateSource(params string[] strs);
}