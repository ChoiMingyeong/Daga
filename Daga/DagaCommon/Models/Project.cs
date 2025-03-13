using System.Data;

namespace DagaCommon.Models
{
    public class Project
    {
        public ulong ID { get; init; }

        public string Name { get; init; } = string.Empty;

        public List<Role> Roles { get; private set; } = [];

        public List<Account> Accounts { get; private set; } = [];

        public List<DataTable> DataTables { get; private set; } = [];
    }
}
