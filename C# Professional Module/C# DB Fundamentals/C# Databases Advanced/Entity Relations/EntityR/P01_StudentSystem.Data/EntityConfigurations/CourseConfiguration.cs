namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(pk => pk.CourseId);

            builder.Property(n => n.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            builder.Property(d => d.Description)
                .IsUnicode()
                .IsRequired(false);

            builder.Property(sd => sd.StartDate)
                .IsRequired();

            builder.Property(ed => ed.EndDate)
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();
        }
    }
}
