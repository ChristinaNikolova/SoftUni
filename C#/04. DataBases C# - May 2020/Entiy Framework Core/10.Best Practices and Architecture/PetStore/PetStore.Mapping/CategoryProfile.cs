using AutoMapper;

using PetStore.Models;
using PetStore.Services.Models.Categories.InputModels;
using PetStore.Services.Models.Categories.OutputModels;

namespace PetStore.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<AddCategoryInputModel, Category>();

            this.CreateMap<EditCategoryInputModel, Category>();

            this.CreateMap<Category, GetCategoiesOutputModel>();
        }
    }
}
