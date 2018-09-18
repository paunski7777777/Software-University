namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(pk => pk.TownId);

            builder.Property(n => n.Name)
                .IsRequired();

            builder.HasOne(c => c.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(fk => fk.CountryId);
        }
    }
}