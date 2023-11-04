using IRunes.Services.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
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

            var userId = this.GetUserId();

            var homeViewModel = this.usersService.GetUsername(userId);

            return this.View(homeViewModel, "Home");
        }
    }
}
