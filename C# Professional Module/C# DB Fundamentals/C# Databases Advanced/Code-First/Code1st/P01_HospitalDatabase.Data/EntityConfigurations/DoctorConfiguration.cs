namespace P01_HospitalDatabase.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(pk => pk.DoctorId);

            builder.Property(n => n.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(s => s.Specialty)
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasMany(v => v.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey(di => di.DoctorId);
        }
    }
}
