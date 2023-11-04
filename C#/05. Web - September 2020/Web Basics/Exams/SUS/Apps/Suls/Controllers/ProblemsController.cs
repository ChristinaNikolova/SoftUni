using Suls.Services.Problems;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Suls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProblemInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 5 || input.Name.Length > 20)
            {
                return this.Redirect("/Problems/Create");
            }

            if (input.Points < 50 || input.Points > 300)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.CreateProblem(input.Name, input.Points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.GetDetailsProblem(id);

            return this.View(problem);
        }
    }
}
