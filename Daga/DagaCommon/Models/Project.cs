using System.Data;

namespace DagaCommon.Models
{
    public class Project
    {
        public ulong ID { get; init; }

        public string Name { get; set; } = string.Empty;

        public bool Favorite { get; set; } = false;

        public string Description { get; set; } = string.Empty;

        public List<Role> Roles { get; set; } = [];

        public Dictionary<uint, byte> Accounts { get; set; } = [];

        public List<DataTable> DataTables { get; set; } = [];
    }
}
