using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.Services.Contracts;
using PetStore.Services.Models.Products.InputModels;
using PetStore.Services.Models.Products.OutputModels;


namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputModel model)
        {
            Product product = this.mapper.Map<Product>(model);

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();
        }

        public void EditProduct(int id, EditProductInputModel model)
        {
            Product newProduct = this.mapper.Map<Product>(model);

            Product productToUpdate = this.dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (productToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            productToUpdate.Name = newProduct.Name;
            productToUpdate.Price = newProduct.Price;
            productToUpdate.ProductType = newProduct.ProductType;
            productToUpdate.Description = newProduct.Description;

            this.dbContext.Products.Update(productToUpdate);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<GetProductsOutputModel> GetAllProducts()
        {
            List<GetProductsOutputModel> products = this.dbContext
                .Products
                .ProjectTo<GetProductsOutputModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.ProductType)
                .ThenBy(p => p.ProductType)
                .ToList();

            return products;
        }

        public IEnumerable<GetProductsOutputModel> GetAllProductsByProductType(string productType)
        {
            bool isProductType = Enum.TryParse<ProductType>(productType, out ProductType result);

            if (!isProductType)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            List<GetProductsOutputModel> products = this.dbContext
                .Products
                .Where(p => p.ProductType == result)
                .ProjectTo<GetProductsOutputModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.ProductType)
                .ToList();

            return products;
        }

        public bool RemoveById(int id)
        {
            Product productToRemove = this.dbContext
                .Products
                .FirstOrDefault(p => p.Id == id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int affectedRows = this.dbContext.SaveChanges();

            bool isSuccessfull = affectedRows == 1;

            return isSuccessfull;
        }

        public IEnumerable<GetProductsOutputModel> SearchByName(string productName)
        {
            List<GetProductsOutputModel> products = this.dbContext
                .Products
                .Where(p => EF.Functions.Like(p.Name.ToLower(), $"%{productName.ToLower()}%"))
                .ProjectTo<GetProductsOutputModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.Price)
                .ToList();

            return products;
        }
    }
}
