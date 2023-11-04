using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

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
                //string inputXml = File.ReadAllText(@"../../../Datasets/users.xml");
                //string result = ImportUsers(context, inputXml);

                //02. Import Products
                //string inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
                //string result = ImportProducts(context, inputXml);

                //03. Import Categories
                //string inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
                //string result = ImportCategories(context, inputXml);

                //04. Import Categories and Products
                //string inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
                //string result = ImportCategoryProducts(context, inputXml);

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
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportUserDto>), new XmlRootAttribute("Users"));

            List<ImportUserDto> importUserDtos =
                (List<ImportUserDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<User> users = importUserDtos
                .Select(i => new User()
                {
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Age = i.Age,
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ImportProductDto>), new XmlRootAttribute("Products"));

            List<ImportProductDto> importProductDtos =
                (List<ImportProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Product> products = importProductDtos
                .Select(i => new Product()
                {
                    Name = i.Name,
                    Price = i.Price,
                    BuyerId = i.BuyerId,
                    SellerId = i.SellerId,
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();


            return $"Successfully imported {products.Count()}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
               new XmlSerializer(typeof(List<ImportCategoryDto>), new XmlRootAttribute("Categories"));

            List<ImportCategoryDto> importCategoryDtos =
                (List<ImportCategoryDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<Category> categories = importCategoryDtos
                .Where(i => i.Name != null)
                .Select(i => new Category()
                {
                    Name = i.Name,
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer =
               new XmlSerializer(typeof(List<ImportCategoryProductDto>), new XmlRootAttribute("CategoryProducts"));

            List<ImportCategoryProductDto> importCategoryProductDtos =
                (List<ImportCategoryProductDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            List<CategoryProduct> categoryProducts = importCategoryProductDtos
                .Where(i => context.Categories.Any(c => c.Id == i.CategoryId)
                         && context.Products.Any(p => p.Id == i.ProductId))
                .Select(i => new CategoryProduct()
                {
                    CategoryId = i.CategoryId,
                    ProductId = i.ProductId
                })
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportGetProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetProductsInRangeDto>), new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportGetSoldProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(ps => ps.Buyer != null)
                    .Select(ps => new ExportSoldProductDto
                    {
                        Name = ps.Name,
                        Price = ps.Price,
                    })
                    .ToArray()
                })
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetSoldProductsDto>), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new ExportGetCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price),
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(List<ExportGetCategoriesByProductsCountDto>),
                new XmlRootAttribute("Categories"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Where(ps => ps.Buyer != null).Count())
                .Take(10)
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportUsersSoldProductDto
                    {
                        Count = u.ProductsSold.Where(ps => ps.Buyer != null).Count(),
                        Products = u.ProductsSold
                        .Where(ps => ps.Buyer != null)
                        .OrderByDescending(ps => ps.Price)
                        .Select(ps => new ExportSoldProductToken
                        {
                            Name = ps.Name,
                            Price = ps.Price,
                        })
                        .ToArray()
                    }
                })
                .ToArray();

            var finalUsers = new ExportGetUsersWithProductsDto
            {
                Count = context.Users.Where(u => u.ProductsSold.Any(ps => ps.Buyer != null)).Count(),
                Users = users,
            };

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportGetUsersWithProductsDto), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty,
            });

            xmlSerializer.Serialize(new StringWriter(sb), finalUsers, namespaces);

            return sb.ToString().TrimEnd();
        }
        private static void ResetDb(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}