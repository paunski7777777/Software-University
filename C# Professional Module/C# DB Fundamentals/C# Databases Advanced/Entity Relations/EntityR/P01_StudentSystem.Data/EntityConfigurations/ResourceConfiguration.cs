namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(pk => pk.ResourceId);

            builder.Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(u => u.Url)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(rt => rt.ResourceType)
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(r => r.Resources)
                .HasForeignKey(fk => fk.CourseId);
        }
    }
}
