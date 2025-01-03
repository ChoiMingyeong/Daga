namespace DagaDataGenerator.SrcGenerator.Packet;

public class PacketSrcGenerator : ISrcGenerator
{
    public bool AddEntity()
    {
        throw new NotImplementedException();
    }
    public bool CreateSource()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}