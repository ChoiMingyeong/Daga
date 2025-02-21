namespace OpsCommon
{
    public enum PageType : byte
    {
        GateHub = 0,
    }

    public enum PermissionType : byte
    {
        Read    = 1 << 0,       // 0001
        Write   = 1 << 1,       // 0010
        Edit    = 1 << 2,       // 0100
        Delte   = 1 << 3,       // 1000
    }

    public class Role
    {
        public byte Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Permission> Permissions { get; set; } = [];
    }

    public class Permission
    {
        public PageType PageType { get; set; }

        public PermissionType PermissionType { get; set; }
    }
}
