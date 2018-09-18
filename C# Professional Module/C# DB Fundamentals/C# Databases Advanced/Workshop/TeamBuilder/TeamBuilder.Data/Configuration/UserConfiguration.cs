namespace TeamBuilder.Data.Configuration
{
    using TeamBuilder.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username)
                   .IsUnique();

            builder.HasMany(ct => ct.CreatedEvents)
                   .WithOne(c => c.Creator)
                   .HasForeignKey(fk => fk.CreatorId)
                   .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(ce => ce.CreatedUserTeams)
            //       .WithOne(c => c.User)
            //       .HasForeignKey(fk => fk.UserId)
            //       .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ri => ri.ReceivedInvitations)
                   .WithOne(iu => iu.InvitedUser)
                   .HasForeignKey(fk => fk.InvitedUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}