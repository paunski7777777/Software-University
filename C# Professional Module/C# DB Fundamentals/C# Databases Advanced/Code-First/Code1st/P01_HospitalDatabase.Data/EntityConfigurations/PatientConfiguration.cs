namespace P01_HospitalDatabase.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(pk => pk.PatientId);

            builder.Property(fn => fn.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(ln => ln.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(a => a.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(pi => pi.PatientId);

            builder.HasMany(v => v.Visitations)
               .WithOne(v => v.Patient)
               .HasForeignKey(pi => pi.PatientId);

            builder.HasMany(d => d.Diagnoses)
               .WithOne(d => d.Patient)
               .HasForeignKey(pi => pi.PatientId);
        }
    }
}
