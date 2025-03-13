namespace DagaCommon.Models
{
    public class Account
    {
        public uint ID { get; set; }

        public ushort RoleID { get; set; } = Role.Guest.ID;

        public List<Project> Projects { get; set; } = [];
    }
}
