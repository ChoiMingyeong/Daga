using System.Data;

namespace DagaKit.Models
{
    public class DagaDatatable : DataTable
    {
        public List<DataColumn> DataColumns => [.. Columns.Cast<DataColumn>()];

        public ushort Id { get; init; }

        public DagaDatatable(string tableName) : base(tableName)
        {
            DataColumn idColumn = new("Id", typeof(uint))
            {
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ReadOnly = true
            };
            Columns.Add(idColumn);
        }
    }
}
