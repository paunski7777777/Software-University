namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(pk => pk.PlayerId);

            builder.Property(n => n.Name)
                .IsRequired();

            builder.Property(i => i.IsInjured)
                .HasDefaultValue(false);

            builder.HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.TeamId);

            builder.HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(fk => fk.PositionId);
        }
    }
}