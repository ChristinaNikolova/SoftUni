using Git.Data;
using Git.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services.Commits
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateCommit(string description, string id, string userId)
        {
            var commit = new Commit()
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = id,
                CreatorId = userId,
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
        }

        public bool DeleteCommit(string id, string userId)
        {
            var isSuccess = true;

            var commit = this.db
                .Commits
                .FirstOrDefault(c => c.Id == id);

            if (commit.CreatorId != userId)
            {
                isSuccess = false;
                return isSuccess;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();

            return isSuccess;
        }

        public IEnumerable<AllCommitsViewModel> GetAll(string userId)
        {
            var commits = this.db
                .Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new AllCommitsViewModel()
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToString("dd.MM.yyyy HH:mm:ss"),
                    Repository = c.Repository.Name,
                })
                .ToList();

            return commits;
        }
    }
}
