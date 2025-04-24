using DagaKit.Models;
using TSID.Creator.NET;
namespace DagaKit.Services
{

    public class DataTableService
    {
        public List<DagaDataTable> DataTables { get; private set; } = [];
        public DagaDataTable? SelectedDataTable { get; set; } = null;

        public DataTableService()
        {
        }

        public async Task LoadDataTablesAsync(Tsid projectTsid)
        {
            // Simulate loading data tables from a database or API
            await Task.Delay(100);
            DataTables = [.. TempDb.DataTables.Where(dt => dt.Project.Tsid == projectTsid)];
        }

        public void SelectDataTable(in DagaDataTable dataTable)
        {
            SelectedDataTable = dataTable;
        }

        public void AddDataTable(string tableName)
        {
        }
        public void RemoveDataTable(DagaDataTable dataTable)
        {
            DataTables.Remove(dataTable);
        }
    }
}
