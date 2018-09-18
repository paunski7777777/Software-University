namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourses");

            builder.HasKey(pk => new
            {
                pk.CourseId,
                pk.StudentId
            });

            builder.HasOne(s => s.Student)
                .WithMany(c => c.CourseEnrollments)
                .HasForeignKey(fk => fk.StudentId);

            builder.HasOne(c => c.Course)
                .WithMany(s => s.StudentsEnrolled)
                .HasForeignKey(fk => fk.CourseId);
        }
    }
}
