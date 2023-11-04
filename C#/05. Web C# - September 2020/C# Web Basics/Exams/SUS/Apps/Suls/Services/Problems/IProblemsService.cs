using Suls.ViewModels.Home;
using Suls.ViewModels.Problems;
using Suls.ViewModels.Submissions;
using System.Collections.Generic;

namespace Suls.Services.Problems
{
    public interface IProblemsService
    {
        IEnumerable<HomeViewModel> GetAll();

        void CreateProblem(string name, int points);

        CreateSubmissionInputModel GetProblemById(string id);

        DetailsProblemViewModel GetDetailsProblem(string id);
    }
}
