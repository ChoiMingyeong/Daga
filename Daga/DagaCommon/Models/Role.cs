using DagaCommon.Enums;

namespace DagaCommon.Models
{
    public class Role
    {
        public readonly static Role Guest = new()
        {
            ID = 0,
            Name = nameof(Guest),
        };

        public readonly static Role Admin = new()
        {
            ID = 1,
            Name = nameof(Admin),
        };

        public byte ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Dictionary<PermissionType, Privileges> Permissions { get; set; } = [];
    }
}
