namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(pk => pk.TeamId);

            builder.Property(n => n.Name)
                .IsRequired();

            builder.Property(i => i.Initials)
                .HasColumnType("NCHAR(3)")
                .IsRequired();

            builder.Property(lu => lu.LogoUrl)
                .IsUnicode(false);

            builder.HasOne(pkc => pkc.PrimaryKitColor)
                .WithMany(pkt => pkt.PrimaryKitTeams)
                .HasForeignKey(fk => fk.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(skc => skc.SecondaryKitColor)
               .WithMany(skt => skt.SecondaryKitTeams)
               .HasForeignKey(fk => fk.SecondaryKitColorId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(fk => fk.TownId);
        }
    }
}