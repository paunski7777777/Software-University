namespace P01_HospitalDatabase.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(pk => pk.DiagnoseId);

            builder.Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }
    }
}
