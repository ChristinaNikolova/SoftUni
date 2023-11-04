using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PetStore.Models;

namespace PetStore.Data.Configurations
{
    public class ClientProductConfiguration : IEntityTypeConfiguration<ClientProduct>
    {
        public void Configure(EntityTypeBuilder<ClientProduct> clientProduct)
        {
            clientProduct
                .HasKey(x => new { x.ClientId, x.ProductId });

            clientProduct
                .HasOne(cp => cp.Client)
                .WithMany(c => c.ClientProducts)
                .HasForeignKey(cp => cp.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            clientProduct
                .HasOne(cp => cp.Product)
                .WithMany(p => p.ClientProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            clientProduct
                .HasOne(cp => cp.Order)
                .WithMany(o => o.ClientProducts)
                .HasForeignKey(cp => cp.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
