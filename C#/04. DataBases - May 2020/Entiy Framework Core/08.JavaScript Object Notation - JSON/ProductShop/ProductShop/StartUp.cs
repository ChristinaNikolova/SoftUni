using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (ProductShopContext context = new ProductShopContext())
            {
                //ResetDb(context);

                //01. Import Users
                //string inputJson = File.ReadAllText("users.json");
                //string result = ImportUsers(context, inputJson);

                //02. Import Products
                //string inputJson = File.ReadAllText("products.json");
                //string result = ImportProducts(context, inputJson);

                //03. Import Categories
                //string inputJson = File.ReadAllText("categories.json");
                //string result = ImportCategories(context, inputJson);

                //04. Import Categories and Products
                //string inputJson = File.ReadAllText("categories-products.json");
                //string result = ImportCategoryProducts(context, inputJson);

                //05. Export Products In Range
                //string result = GetProductsInRange(context);

                //06. Export Sold Products
                //string result = GetSoldProducts(context);

                //07. Export Categories By Products Count
                //string result = GetCategoriesByProductsCount(context);

                //08. Export Users and Products
                string result = GetUsersWithProducts(context);

                Console.WriteLine(result);
            }
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<User> users = JsonConvert
                .DeserializeObject<List<User>>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            List<Product> products = JsonConvert
                .DeserializeObject<List<Product>>(inputJson)
                .Where(p => p.Name != null && p.Name.Length >= 3)
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            List<Category> categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null && (c.Name.Length >= 3 && c.Name.Length <= 15))
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            List<CategoryProduct> categoryProducts = JsonConvert
                .DeserializeObject<List<CategoryProduct>>(inputJson)
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(products, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
            });

            return jsonResult.TrimEnd();
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(ps => ps.Buyer != null)
                    .Select(ps => new
                    {
                        ps.Name,
                        ps.Price,
                        BuyerFirstName = ps.Buyer.FirstName,
                        BuyerLastName = ps.Buyer.LastName,
                    })
                    .ToList()
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(users, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
            });

            return jsonResult.TrimEnd();
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2"),
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
            });

            return jsonResult.TrimEnd();
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Where(ps => ps.Buyer != null).Count(),
                        Products = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .Select(ps => new
                        {
                            ps.Name,
                            ps.Price,
                        })
                        .ToList()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToList();

            var finalUsers = new
            {
                UsersCount = users.Count,
                users,
            };

            string jsonResult = JsonConvert.SerializeObject(finalUsers, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
            });

            return jsonResult.TrimEnd();
        }

        private static void ResetDb(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}