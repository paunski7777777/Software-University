namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(pk => pk.GameId);

            builder.HasOne(ht => ht.HomeTeam)
                .WithMany(hg => hg.HomeGames)
                .HasForeignKey(fk => fk.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(at => at.AwayTeam)
                .WithMany(ag => ag.AwayGames)
                .HasForeignKey(fk => fk.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}