using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Services.Models.Products.InputModels
{
    public class EditProductInputModel
    {
        [Required]
        [MinLength(GlobalConstants.ProductMinNameLen)]
        [MaxLength(GlobalConstants.ProductMaxNameLen)]
        public string Name { get; set; }

        [Range(GlobalConstants.ProductMinPrice, GlobalConstants.ProductMaxPrice)]
        public decimal Price { get; set; }

        [Required]
        public string ProductType { get; set; }

        [MaxLength(GlobalConstants.ProductDescriptionMaxLen)]
        public string Description { get; set; }
    }
}
