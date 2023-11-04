using Suls.Services.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Net.NetworkInformation;

namespace Suls.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }


        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            if (!this.IsUserSignedIn())
            {
                return this.View();
            }

            var problems = this.problemsService.GetAll();

            return this.View(problems, "IndexLoggedIn");
        }
    }
}
