using System;

using AutoMapper;

using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.Services.Models.Products.InputModels;
using PetStore.Services.Models.Products.OutputModels;


namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));

            this.CreateMap<Product, GetProductsOutputModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<EditProductInputModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));
        }
    }
}
