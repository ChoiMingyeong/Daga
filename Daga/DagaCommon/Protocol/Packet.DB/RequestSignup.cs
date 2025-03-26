using MemoryPack;

namespace DagaCommon.Protocol
{
    [MemoryPackable]
    public partial class RequestSignup : IPacket
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
