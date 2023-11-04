using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Services.Models.Breeds.InputModels
{
    public class AddBreedInputModel
    {
        [Required]
        [MinLength(GlobalConstants.BreedMinNameLen)]
        [MaxLength(GlobalConstants.BreedMaxNameLen)]
        public string Name { get; set; }
    }
}
