using MemoryPack;

namespace DagaDev
{
    [MemoryPackable]
    public partial class TestPacket :IPacket
    {
        public uint PacketID { get; init; } = 0;

        public int AA {  get; set; }
    }

    [MemoryPackable]
    public partial class TestPacket2 : IPacket
    {
        public uint PacketID { get; init; } = 1;

        public string? BB { get; set; }
    }
}
