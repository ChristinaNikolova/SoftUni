using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;
using PetStore.Models.Enums;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            this.ClientProducts = new HashSet<ClientProduct>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.ProductMinNameLen)]
        [MaxLength(GlobalConstants.ProductMaxNameLen)]
        public string Name { get; set; }

        [Range(GlobalConstants.ProductMinPrice, GlobalConstants.ProductMaxPrice)]
        public decimal Price { get; set; }

        public ProductType ProductType { get; set; }

        [MaxLength(GlobalConstants.ProductDescriptionMaxLen)]
        public string Description { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
