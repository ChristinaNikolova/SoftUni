using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Models
{
    public class Category
    {
        public Category()
        {
            this.Pets = new HashSet<Pet>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CategoryMinNameLen)]
        [MaxLength(GlobalConstants.CategoryMaxNameLen)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.CategoryDescriptionMaxLen)]
        public string Description { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}