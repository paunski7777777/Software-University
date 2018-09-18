namespace TeamBuilder.Data.Configuration
{
    using TeamBuilder.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventTeamConfiguration : IEntityTypeConfiguration<EventTeam>
    {
        public void Configure(EntityTypeBuilder<EventTeam> builder)
        {
            builder.HasKey(pk => new
            {
                pk.EventId,
                pk.TeamId
            });

            builder.HasOne(e => e.Event)
                   .WithMany(pet => pet.ParticipatingEventTeams)
                   .HasForeignKey(fk => fk.EventId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Team)
                   .WithMany(et => et.Events)
                   .HasForeignKey(fk => fk.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}