using MemoryPack;

namespace DagaNetwork
{
    [MemoryPackable]
    public partial class TestPacket2 : IPacket
    {
        public uint PacketID { get; init; } = 1;

        public string? BB { get; set; }
    }
}
