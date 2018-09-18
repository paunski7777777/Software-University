namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasAlternateKey(u => u.Username);

            builder.HasMany(f => f.Followers)
                   .WithOne(u => u.User)
                   .HasForeignKey(fk => fk.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ProfilePicture)
                   .WithMany(u => u.Users)
                   .HasForeignKey(fk => fk.ProfilePictureId);

            builder.HasMany(u => u.UsersFollowing)
                   .WithOne(f => f.Follower)
                   .HasForeignKey(fk => fk.FollowerId);
        }
    }
}