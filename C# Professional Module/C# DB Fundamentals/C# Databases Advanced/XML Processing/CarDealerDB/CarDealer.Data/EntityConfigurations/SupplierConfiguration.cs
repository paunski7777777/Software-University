namespace CarDealer.Data.EntityConfigurations
{
    using CarDealer.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasMany(p => p.Parts)
                   .WithOne(s => s.Supplier)
                   .HasForeignKey(fk => fk.SupplierId);
        }
    }
}