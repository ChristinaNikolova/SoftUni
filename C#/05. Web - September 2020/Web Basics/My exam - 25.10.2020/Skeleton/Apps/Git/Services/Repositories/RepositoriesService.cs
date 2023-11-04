using Git.Data;
using Git.Models;
using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services.Repositories
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(string name, string repositoryType, string userId)
        {
            var repository = new Repository()
            {
                Name = name,
                IsPublic = repositoryType == "Public" ? true : false,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<AllRepositoriesViewModel> GetAll()
        {
            var repositories = this.db
                 .Repositories
                 .Where(r => r.IsPublic == true)
                 .Select(r => new AllRepositoriesViewModel()
                 {
                     Id = r.Id,
                     Name = r.Name,
                     Owner = r.Owner.Username,
                     CreatedOn = r.CreatedOn.ToString("dd.MM.yyyy HH:mm:ss"),
                     Commits = r.Commits.Count(),
                 })
                 .ToList();

            return repositories;
        }

        public CreateCommitInputModel GetRepositoty(string id)
        {
            var createCommitInputModel = this.db
                .Repositories
                .Where(r => r.Id == id)
                .Select(r => new CreateCommitInputModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                })
                .FirstOrDefault();

            return createCommitInputModel;
        }
    }
}
