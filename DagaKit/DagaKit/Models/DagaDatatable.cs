using TSID.Creator.NET;
using System.Data;

namespace DagaKit.Models
{
    public class DagaDataTable : DataTable
    {
        public readonly ProjectModel Project;

        public Tsid Tsid { get; init; }

        public List<DataColumn> DataColumns => [.. Columns.Cast<DataColumn>()];

        public DagaDataTable(in ProjectModel project, string tableName) : base(tableName)
        {
            Project = project;
            DataColumn idColumn = new("Id", typeof(ulong))
            {
                ReadOnly = true
            };
            Columns.Add(idColumn);
        }
    }
}