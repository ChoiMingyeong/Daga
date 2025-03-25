using System.Data;

namespace DagaCommon.Models
{
    public class Project
    {
        private static ulong _id = 1;

        public ulong ID { get; init; } = _id++;

        public string Name { get; set; } = string.Empty;

        public List<Role> Roles { get; set; } = [];

        public Dictionary<uint, Role> Accounts { get; set; } = [];

        public List<DataTable> DataTables { get; set; } = [];
    }
}
