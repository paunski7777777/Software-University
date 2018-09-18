namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(u => u.User)
                   .WithMany(c => c.Comments)
                   .HasForeignKey(fk => fk.UserId);

            builder.HasOne(p => p.Post)
                   .WithMany(c => c.Comments)
                   .HasForeignKey(fk => fk.PostId);
        }
    }
}