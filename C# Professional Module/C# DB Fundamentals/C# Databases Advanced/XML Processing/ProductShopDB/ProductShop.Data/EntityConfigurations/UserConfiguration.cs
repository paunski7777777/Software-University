namespace ProductShop.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using ProductShop.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(p => p.ProductsSold)
                   .WithOne(s => s.Seller)
                   .HasForeignKey(fk => fk.SellerId);

            builder.HasMany(p => p.ProductsBought)
                   .WithOne(b => b.Buyer)
                   .HasForeignKey(fk => fk.BuyerId);
        }
    }
}
