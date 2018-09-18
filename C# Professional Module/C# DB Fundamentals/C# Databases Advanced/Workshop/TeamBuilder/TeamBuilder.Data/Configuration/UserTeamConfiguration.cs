namespace TeamBuilder.Data.Configuration
{
    using TeamBuilder.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.HasKey(pk => new
            {
                pk.UserId,
                pk.TeamId
            });

            builder.HasOne(u => u.User)
                   .WithMany(ut => ut.UserTeams)
                   .HasForeignKey(fk => fk.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Team)
                   .WithMany(ut => ut.Members)
                   .HasForeignKey(fk => fk.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}