namespace CarDealer.Data.EntityConfigurations
{
    using CarDealer.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasMany(c => c.Cars)
                   .WithOne(p => p.Part)
                   .HasForeignKey(fk => fk.PartId);
        }
    }
}