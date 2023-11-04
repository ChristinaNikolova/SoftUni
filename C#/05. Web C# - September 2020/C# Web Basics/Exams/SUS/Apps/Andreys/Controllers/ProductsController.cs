using Andreys.Services.Products;
using Andreys.ViewModels.Products;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddProductInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Description.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (string.IsNullOrWhiteSpace(input.Category))
            {
                return this.Redirect("/Products/Add");
            }

            if (string.IsNullOrWhiteSpace(input.Gender))
            {
                return this.Redirect("/Products/Add");
            }

            if (!Uri.TryCreate(input.ImageUrl, UriKind.Absolute, out _))
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.AddProduct(input.Name, input.Description, input.Price, input.ImageUrl, input.Category, input.Gender);

            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.DetailsProduct(id);

            return this.View(product);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.productsService.DeleteProduct(id);

            return this.Redirect("/");
        }
    }
}
