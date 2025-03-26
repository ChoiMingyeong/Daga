using DagaCommon.Models;

namespace DagaTools.Services
{
    public partial class AuthService
    {
        private async Task LoadProjectsAsync()
        {
            if (null == Account)
            {
                Projects.Clear();
                return;
            }

            Projects = await _dbService.GetProjectsAsync(Account.ID) ?? [];
        }

        public async Task<bool> CreateProjectAsync(string projectName, string projectDescription)
        {
            if (null == Account)
            {
                return false;
            }

            if (false == await _dbService.CreateProjectAsync(Account.ID, projectName, projectDescription))
            {
                return false;
            }

            await LoadProjectsAsync();
            return true;
        }


        public async Task<bool> UpdateProjectFavoriteAsync(ulong projectID, bool favorite)
        {
            if (null == Account)
            {
                return false;
            }

            if (false == await _dbService.UpdateProjectFavoriteAsync(Account.ID, projectID, favorite)
                || Projects.SingleOrDefault(p => p.ID == projectID) is not Project project)
            {
                return false;
            }

            project.Favorite = favorite;
            return true;
        }
    }
}
