using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Services.Models.Pets.InputModels
{
    public class AddPetInputModel
    {
        [Required]
        [MinLength(GlobalConstants.PetMinNameLen)]
        [MaxLength(GlobalConstants.PetMaxNameLen)]
        public string Name { get; set; }

        public string Gender { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        [Range(GlobalConstants.PetMinPrice, GlobalConstants.petMaxPrice)]
        public decimal Price { get; set; }

        [MaxLength(GlobalConstants.PetDescriptionMaxLen)]
        public string Desctiption { get; set; }

        [Required]
        public string Breed { get; set; }

        public bool IsSold { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
