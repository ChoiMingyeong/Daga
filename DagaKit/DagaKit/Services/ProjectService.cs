using DagaKit.Models;
using TSID.Creator.NET;

namespace DagaKit.Services
{
    public class ProjectService
    {
        public List<ProjectModel> Projects { get; private set; } = [];

        public ProjectModel? SelectedProject { get; set; } = null;

        private readonly DataTableService _dataTableService;

        public ProjectService(DataTableService dataTableService)
        {
            _dataTableService = dataTableService;
        }

        public async Task LoadProjectsAsync()
        {
            // Simulate loading projects from a database or API
            await Task.Delay(1000);
            Projects =
            [
                new ProjectModel ("Project A"),
                new ProjectModel ("Project B"),
                new ProjectModel ("Project C"),
            ];

            foreach (var project in Projects)
            {
                // Simulate loading data tables for each project
                await _dataTableService.LoadDataTablesAsync(project.Tsid);
            }
        }
    }
}
