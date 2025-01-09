namespace DagaDataGenerator.SrcGenerator.Packet;

public class PacketSrcGenerator(string @namespace) : ISrcGenerator
{
    public string Namespace { get; set; } = @namespace;

    public bool CreateSource(params string[] strs)
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