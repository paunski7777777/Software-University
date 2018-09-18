namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserFollowerConfiguration : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(pk => new
            {
                pk.UserId,
                pk.FollowerId
            });
        }
    }
}