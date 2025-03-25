using DagaCommon.Models;

namespace DagaTools.Services
{
    public partial class AuthService
    {
        public List<Project> Projects = [];

        public Project? SelectedProject { get; set; } = null;

        public void Initialize()
        {

        }

        public void Reset()
        {
            SelectedProject = null;
            Projects.Clear();
        }
    }
}
