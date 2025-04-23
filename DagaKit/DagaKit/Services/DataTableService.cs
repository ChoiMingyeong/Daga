using DagaKit.Models;
using TSID.Creator.NET;
namespace DagaKit.Services
{
    public static class TempDb
    {
        public static List<ProjectModel> Projects { get; set; } = [new("ProjectA"), new("ProjectB"), new("ProjectC")];

        public static List<DagaDataTable> DataTables { get; set; } = [
            new(Projects[0], "DataTableA1"), new(Projects[0], "DataTableA2"),new(Projects[0], "DataTableA3"),
            new(Projects[1], "DataTableB1"), new(Projects[0], "DataTableB2"),new(Projects[0], "DataTableB3"),
            new(Projects[2], "DataTableC1"), new(Projects[0], "DataTableC2"),new(Projects[0], "DataTableC3"),
            ];
    }

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
            await Task.Delay(1000);
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
