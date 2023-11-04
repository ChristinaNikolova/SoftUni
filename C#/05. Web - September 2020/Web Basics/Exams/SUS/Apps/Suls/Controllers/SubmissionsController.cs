using Suls.Services.Problems;
using Suls.Services.Submissions;
using Suls.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var createViewInputModel = this.problemsService.GetProblemById(id);

            return this.View(createViewInputModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateSubmissionInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Code) || input.Code.Length < 30 || input.Code.Length > 800)
            {
                return this.Redirect($"/Submissions/Create?id={input.ProblemId}");
            }

            var userId = this.GetUserId();

            this.submissionsService.CreateSubmission(input.Code, input.ProblemId, userId);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.DeleteSubmission(id);

            return this.Redirect("/");
        }
    }
}
