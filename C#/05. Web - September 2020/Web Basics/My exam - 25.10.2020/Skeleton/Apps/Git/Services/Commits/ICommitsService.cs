using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services.Commits
{
    public interface ICommitsService
    {
        void CreateCommit(string description, string id, string userId);

        IEnumerable<AllCommitsViewModel> GetAll(string userId);

        bool DeleteCommit(string id, string userId);
    }
}
