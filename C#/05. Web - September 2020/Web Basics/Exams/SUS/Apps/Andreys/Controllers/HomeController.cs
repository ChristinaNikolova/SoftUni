using Andreys.Services.Products;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Andreys.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
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

            var products = this.productsService.GetAll();

            return this.View(products, "Home");
        }
    }
}
