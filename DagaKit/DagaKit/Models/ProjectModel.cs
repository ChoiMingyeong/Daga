using DagaKit.Services;
using TSID.Creator.NET;

namespace DagaKit.Models
{
    public class ProjectModel
    {
        public Tsid Tsid { get; init; }

        public string Name { get; set; } = string.Empty;

        public List<DagaDataTable> DataTables { get; set; } = [];

        public ProjectModel(string name)
        {
            Tsid = TsidCreator.GetTsid();
            Name = name;
        }

        public ProjectModel(Tsid tsid)
        {
            Tsid = tsid;
            Name = TempDb.Projects.Single(p => p.Tsid == tsid).Name;
        }
    }
}
