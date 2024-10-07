using MemoryPack;

namespace DagaDev
{
    [MemoryPackable]
    public partial class TestPacket :IPacket
    {
        public uint GetPacketID()
        {
            return 0;
        }

        public int AA {  get; set; }
    }
}
