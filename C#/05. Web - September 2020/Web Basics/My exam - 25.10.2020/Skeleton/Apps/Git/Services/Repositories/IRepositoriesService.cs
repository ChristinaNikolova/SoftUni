using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services.Repositories
{
    public interface IRepositoriesService
    {
        IEnumerable<AllRepositoriesViewModel> GetAll();

        void CreateRepository(string name, string repositoryType, string userId);

        CreateCommitInputModel GetRepositoty(string id);
    }
}
