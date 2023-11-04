using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Models
{
    public class ClientProduct
    {
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Range(GlobalConstants.MinQuantity, GlobalConstants.MaxQuantity)]
        public int Quantity { get; set; }

        [Required]
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
