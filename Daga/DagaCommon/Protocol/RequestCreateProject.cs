using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class RequestCreateProject : IPacket
    {
        public uint AccountID { get; set; }

        public string ProjectName { get; set; } = string.Empty;
    }
}
