namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(pk => pk.BetId);

            builder.HasOne(g => g.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(fk => fk.GameId);

            builder.HasOne(u => u.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(fk => fk.UserId);
        }
    }
}