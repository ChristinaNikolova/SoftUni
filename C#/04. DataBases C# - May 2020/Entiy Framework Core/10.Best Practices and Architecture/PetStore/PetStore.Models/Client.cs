using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            this.BoughtPets = new HashSet<Pet>();
            this.ClientProducts = new HashSet<ClientProduct>();
        }
        public int Id { get; set; }

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

        public virtual ICollection<Pet> BoughtPets { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
