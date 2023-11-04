using System.Collections.Generic;

using PetStore.Services.Models.Products.InputModels;
using PetStore.Services.Models.Products.OutputModels;

namespace PetStore.Services.Contracts
{
    public interface IProductService
    {
        void AddProduct(AddProductInputModel model);

        IEnumerable<GetProductsOutputModel> GetAllProducts();

        IEnumerable<GetProductsOutputModel> GetAllProductsByProductType(string productType);

        IEnumerable<GetProductsOutputModel> SearchByName(string productName);

        bool RemoveById(int id);

        void EditProduct(int id, EditProductInputModel model);
    }
}
