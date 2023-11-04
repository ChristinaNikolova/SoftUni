using Git.Services.Commits;
using Git.Services.Repositories;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;
        private readonly IRepositoriesService repositoriesService;

        public CommitsController(ICommitsService commitsService, IRepositoriesService repositoriesService)
        {
            this.commitsService = commitsService;
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var commits = this.commitsService.GetAll(userId);

            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var createCommitInputModel = this.repositoriesService.GetRepositoty(id);

            return this.View(createCommitInputModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Description) || input.Description.Length < 5)
            {
                return this.Error("Description is required and have min length of 5 characters.");
            }

            var userId = this.GetUserId();

            this.commitsService.CreateCommit(input.Description, input.Id, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            var isSuccess = this.commitsService.DeleteCommit(id, userId);

            if (!isSuccess)
            {
                return this.Error("Only the commit's creator can delete the selected commit.");
            }

            return this.Redirect("/Commits/All");
        }
    }
}
