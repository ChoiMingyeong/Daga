using DagaKit.Models;
namespace DagaKit.Services
{
    public static class TempDb
    {
        public static List<ProjectModel> Projects { get; set; } = [new("ProjectA"), new("ProjectB"), new("ProjectC")];

        public static List<DagaDataTable> DataTables { get; set; } = [
            new(Projects[0], "DataTableA1"), new(Projects[0], "DataTableA2"),new(Projects[0], "DataTableA3"),
            new(Projects[1], "DataTableB1"), new(Projects[1], "DataTableB2"),new(Projects[1], "DataTableB3"),
            new(Projects[2], "DataTableC1"), new(Projects[2], "DataTableC2"),new(Projects[2], "DataTableC3"),
            ];
    }
}
