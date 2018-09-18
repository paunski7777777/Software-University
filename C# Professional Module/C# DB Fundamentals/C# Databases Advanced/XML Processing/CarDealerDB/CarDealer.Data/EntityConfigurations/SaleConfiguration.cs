namespace CarDealer.Data.EntityConfigurations
{
    using CarDealer.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasOne(c => c.Car)
                   .WithMany(s => s.Sales)
                   .HasForeignKey(fk => fk.CarId);

            builder.HasOne(c => c.Customer)
                   .WithMany(s => s.Sales)
                   .HasForeignKey(fk => fk.CustomerId);
        }
    }
}