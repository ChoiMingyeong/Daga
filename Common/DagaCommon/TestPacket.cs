using MemoryPack;

namespace DagaNetwork
{
    [MemoryPackable]
    public partial class TestPacket :IPacket
    {
        public uint PacketID { get; init; } = 0;

        public int AA {  get; set; }
    }
}
