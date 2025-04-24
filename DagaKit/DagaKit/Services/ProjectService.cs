using DagaKit.Models;
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
            await Task.Delay(100);
            Projects = TempDb.Projects;
        }
    }
}
