using Andreys.Data;
using Andreys.Models;
using Andreys.Models.Enums;
using Andreys.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(string name, string description, decimal price, string imageUrl, string category, string gender)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                Category = Enum.Parse<Category>(category),
                Gender = Enum.Parse<Gender>(gender),
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public Product DetailsProduct(int id)
        {
            Product product = GetProductById(id);

            return product;
        }

        public IEnumerable<HomeViewModel> GetAll()
        {
            var products = this.db
                .Products
                .Select(p => new HomeViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                })
                .ToList();

            return products;
        }

        private Product GetProductById(int id)
        {
            return this.db
                .Products
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
