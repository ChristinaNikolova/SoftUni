using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Services.Models.Categories.InputModels
{
    public class EditCategoryInputModel
    {
        [Required]
        [MinLength(GlobalConstants.CategoryMinNameLen)]
        [MaxLength(GlobalConstants.CategoryMaxNameLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.CategoryDescriptionMaxLen)]
        public string Description { get; set; }
    }
}
