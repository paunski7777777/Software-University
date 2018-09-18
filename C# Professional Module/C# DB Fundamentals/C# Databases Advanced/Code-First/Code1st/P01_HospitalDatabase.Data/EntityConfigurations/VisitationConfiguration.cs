namespace P01_HospitalDatabase.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder.HasKey(pk => pk.VisitationId);

            builder.Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode();
        }
    }
}
