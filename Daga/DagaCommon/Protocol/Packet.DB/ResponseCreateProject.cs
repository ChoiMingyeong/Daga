using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class ResponseCreateProject : IPacket
    {
        public ulong ProjectID { get; set; }
    }
}
