namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(u => u.User)
                   .WithMany(p => p.Posts)
                   .HasForeignKey(fk => fk.UserId);

            builder.HasMany(c => c.Comments)
                   .WithOne(p => p.Post)
                   .HasForeignKey(fk => fk.PostId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}