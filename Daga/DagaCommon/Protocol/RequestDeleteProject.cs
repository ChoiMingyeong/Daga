using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class RequestDeleteProject : IPacket
    {
        public uint AccountID { get; set; }

        public ulong ProjectID { get; set; }
    }
}
