namespace DagaDataGenerator.SrcGenerator.Packet;

public class PacketSrcGenerator : ISrcGenerator
{
    public bool ToSource(string filePath, string fileName)
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