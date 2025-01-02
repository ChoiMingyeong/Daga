namespace DagaDataGenerator.SrcGenerator;

public interface ISrcGenerator : IDisposable
{
    public bool CreateSource();
}