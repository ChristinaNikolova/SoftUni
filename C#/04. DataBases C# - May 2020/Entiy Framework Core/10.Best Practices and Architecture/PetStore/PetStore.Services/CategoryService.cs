using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Contracts;
using PetStore.Services.Models.Categories.InputModels;
using PetStore.Services.Models.Categories.OutputModels;

namespace PetStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void AddCategory(AddCategoryInputModel model)
        {
            Category category = this.mapper.Map<Category>(model);

            this.dbContext.Categories.Add(category);
            this.dbContext.SaveChanges();
        }

        public void EditProduct(int id, EditCategoryInputModel model)
        {
            Category newCategory = this.mapper.Map<Category>(model);

            Category categoryToUpdate = this.dbContext
                .Categories
                .FirstOrDefault(p => p.Id == id);

            if (categoryToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.CategoryNotFound);
            }

            categoryToUpdate.Name = newCategory.Name;
            categoryToUpdate.Description = newCategory.Description;

            this.dbContext.Categories.Update(categoryToUpdate);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<GetCategoiesOutputModel> GetAllCategories()
        {
            List<GetCategoiesOutputModel> categories = this.dbContext
                .Categories
                .ProjectTo<GetCategoiesOutputModel>(this.mapper.ConfigurationProvider)
                .OrderBy(c => c.Name)
                .ToList();

            return categories;
        }

        public bool RemoveById(int id)
        {
            Category categoryToRemove = this.dbContext
                .Categories
                .FirstOrDefault(c => c.Id == id);

            if (categoryToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.CategoryNotFound);
            }

            this.dbContext.Categories.Remove(categoryToRemove);
            int affectedRows = this.dbContext.SaveChanges();

            bool isSuccessfull = affectedRows == 1;

            return isSuccessfull;
        }
    }
}
