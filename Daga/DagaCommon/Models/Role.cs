using DagaCommon.Enums;

namespace DagaCommon.Models
{
    public class Role
    {
        public readonly static Role Guest = new(0, nameof(Guest))
        {
            Description = "Guest",
        };

        public readonly static Role Admin = new(1, nameof(Admin))
        {
            Description = "Admin",
        };

        public ushort ID { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public Dictionary<PermissionType, Privileges> Permissions { get; set; } = [];

        public Role(ushort id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
