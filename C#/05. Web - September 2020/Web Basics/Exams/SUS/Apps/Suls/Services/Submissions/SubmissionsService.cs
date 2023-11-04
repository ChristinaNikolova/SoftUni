using Suls.Data;
using Suls.Models;
using System;
using System.Linq;

namespace Suls.Services.Submissions
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void CreateSubmission(string code, string problemId, string userId)
        {
            var problem = this.db
                .Problems
                .FirstOrDefault(p => p.Id == problemId);

            var submission = new Submission()
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = this.random.Next(0, problem.Points + 1),
                CreatedOn = DateTime.UtcNow,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void DeleteSubmission(string id)
        {
            var submission = this.db
                .Submissions
                .FirstOrDefault(s => s.Id == id);

            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
