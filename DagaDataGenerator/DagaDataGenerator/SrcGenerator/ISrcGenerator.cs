namespace DagaDataGenerator.SrcGenerator;

public interface ISrcGenerator : IDisposable
{
    public bool AddEntity();

    public bool CreateSource();
}