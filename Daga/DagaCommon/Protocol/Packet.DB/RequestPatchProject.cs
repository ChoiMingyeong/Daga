using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class RequestUpdateProjectFavorite : IPacket
    {
        public uint AccountID { get; set; }

        public ulong ProjectID { get; set; }

        public bool Favorite { get; set; }
    }
}
