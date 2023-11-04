using Suls.Data;
using Suls.Models;
using Suls.ViewModels.Home;
using Suls.ViewModels.Problems;
using Suls.ViewModels.Submissions;
using System.Collections.Generic;
using System.Linq;

namespace Suls.Services.Problems
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomeViewModel> GetAll()
        {
            var problems = this.db
                .Problems
                .Select(p => new HomeViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count(),
                })
                .ToList();

            return problems;
        }

        public DetailsProblemViewModel GetDetailsProblem(string id)
        {
            var problem = this.db
                .Problems
                .Where(p => p.Id == id)
                .Select(p => new DetailsProblemViewModel()
                {
                    Name = p.Name,
                    Submissions = p.Submissions
                    .Select(s => new DetailsSubmissionViewModel()
                    {
                        SubmissionId = s.Id,
                        Username = s.User.Username,
                        AchievedResult = s.AchievedResult,
                        MaxPoints = p.Points,
                        CreatedOn = s.CreatedOn.ToShortDateString(),
                    })
                    .ToList()
                })
                .FirstOrDefault();

            return problem;
        }

        public CreateSubmissionInputModel GetProblemById(string id)
        {
            var createSubmissionInpuModel = this.db
                .Problems
                .Where(p => p.Id == id)
                .Select(p => new CreateSubmissionInputModel()
                {
                    ProblemId = p.Id,
                    Name = p.Name,
                })
                .FirstOrDefault();

            return createSubmissionInpuModel;
        }
    }
}
