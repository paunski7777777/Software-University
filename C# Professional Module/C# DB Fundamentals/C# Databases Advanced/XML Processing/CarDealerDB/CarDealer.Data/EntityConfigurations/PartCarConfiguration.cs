namespace CarDealer.Data.EntityConfigurations
{
    using CarDealer.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class PartCarConfiguration : IEntityTypeConfiguration<PartCar>
    {
        public void Configure(EntityTypeBuilder<PartCar> builder)
        {
            builder.HasKey(pk => new
            {
                pk.CarId,
                pk.PartId
            });
        }
    }
}