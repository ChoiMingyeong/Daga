namespace DagaCommon.Models
{
    public class Account
    {
        public uint ID { get; set; }

        public ushort RoleID { get; set; } = Role.Guest.ID;

        public string Email { get; set; } = string.Empty;

        public List<Project> Projects { get; set; } = [];
    }
}
