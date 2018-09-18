namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("HomeworkSubmissions");

            builder.HasKey(pk => pk.HomeworkId);

            builder.Property(c => c.Content)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(ct => ct.ContentType)
                .IsRequired();

            builder.Property(st => st.SubmissionTime)
                .IsRequired();

            builder.HasOne(c => c.Course)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(fk => fk.CourseId);

            builder.HasOne(s => s.Student)
                .WithMany(h => h.HomeworkSubmissions)
                .HasForeignKey(fk => fk.StudentId);
        }
    }
}
