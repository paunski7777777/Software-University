namespace P01_HospitalDatabase.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(pk => pk.MedicamentId);

            builder.Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.HasMany(p => p.Prescriptions)
                .WithOne(m => m.Medicament)
                .HasForeignKey(mi => mi.MedicamentId);
        }
    }
}
