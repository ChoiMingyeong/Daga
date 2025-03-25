using DagaCommon.Models;
using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class ResponseLogin : IPacket
    {
        public uint AccountID { get; set; }

        public string Name { get; set; } = string.Empty;

        public Dictionary<ulong, string> Projects { get; set; } = [];
    }
}
