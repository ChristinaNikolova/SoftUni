using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using PetStore.Common;

namespace PetStore.Models
{
   public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProduct>();
        }
        public string Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(GlobalConstants.AddressMixNameLen)]
        [MaxLength(GlobalConstants.AddressMaxNameLen)]
        public string DeliveryAddress { get; set; }

        [MaxLength(GlobalConstants.NoteMaxLen)]
        public string Notes { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
