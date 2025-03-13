using System.Data;

namespace DagaCommon.Models
{
    public class Project
    {
        public ulong ID { get; init; }

        public string Name { get; set; } = string.Empty;

        public List<Role> Roles { get; set; } = [];

        public List<Account> Accounts { get; set; } = [];

        public List<DataTable> DataTables { get; set; } = [];
    }
}
