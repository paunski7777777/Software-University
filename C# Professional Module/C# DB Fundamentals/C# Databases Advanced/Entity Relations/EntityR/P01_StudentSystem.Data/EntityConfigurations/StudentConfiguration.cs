namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(pk => pk.StudentId);

            builder.Property(n => n.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(pn => pn.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false)
                .IsRequired(false);

            builder.Property(ro => ro.RegisteredOn)
                .IsRequired();

            builder.Property(b => b.Birthday)
                .IsRequired(false);
        }
    }
}
