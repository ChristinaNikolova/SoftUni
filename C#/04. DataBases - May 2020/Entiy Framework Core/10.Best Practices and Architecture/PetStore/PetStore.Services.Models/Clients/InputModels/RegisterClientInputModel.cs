using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Services.Models.Clients.InputModels
{
    public class RegisterClientInputModel
    {
        [Required]
        [MinLength(GlobalConstants.ClientMinNameLen)]
        [MaxLength(GlobalConstants.ClientMaxNameLen)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientMinPasswordLen)]
        [MaxLength(GlobalConstants.ClientMaxPasswordLen)]
        public string Password { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientMinNameLen)]
        [MaxLength(GlobalConstants.ClientMaxNameLen)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.ClientMinNameLen)]
        [MaxLength(GlobalConstants.ClientMaxNameLen)]
        public string LastName { get; set; }

    }
}
