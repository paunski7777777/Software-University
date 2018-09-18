namespace CarDealer.Data.EntityConfigurations
{
    using CarDealer.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasMany(p => p.Parts)
                   .WithOne(c => c.Car)
                   .HasForeignKey(fk => fk.CarId);
        }
    }
}