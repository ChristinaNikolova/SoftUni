using Andreys.Models;
using Andreys.ViewModels.Home;
using System.Collections.Generic;

namespace Andreys.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<HomeViewModel> GetAll();

        void AddProduct(string name, string description, decimal price, string imageUrl, string category, string gender);

        Product DetailsProduct(int id);

        void DeleteProduct(int id);
    }
}
