using DagaCommon.Enums;
using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class RequestCreateRole : IPacket
    {
        public uint AccountID { get; set; }

        public ulong ProjectID { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public Dictionary<PermissionType, Privileges> Permissions { get; set; } = [];
    }
}
