using System.Collections.Generic;

using PetStore.Services.Models.Categories.InputModels;
using PetStore.Services.Models.Categories.OutputModels;

namespace PetStore.Services.Contracts
{
    public interface ICategoryService
    {
        void AddCategory(AddCategoryInputModel model);

        IEnumerable<GetCategoiesOutputModel> GetAllCategories();

        bool RemoveById(int id);

        void EditProduct(int id, EditCategoryInputModel model);
    }
}
