namespace Instagraph.Data.EntityConfiguration
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasMany(p => p.Posts)
                   .WithOne(p => p.Picture)
                   .HasForeignKey(fk => fk.PictureId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}