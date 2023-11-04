using System;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;
using PetStore.Models.Enums;

namespace PetStore.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.PetMinNameLen)]
        [MaxLength(GlobalConstants.PetMaxNameLen)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Range(GlobalConstants.PetMinPrice, GlobalConstants.petMaxPrice)]
        public decimal Price { get; set; }

        [MaxLength(GlobalConstants.PetDescriptionMaxLen)]
        public string Desctiption { get; set; }

        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public bool IsSold { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
