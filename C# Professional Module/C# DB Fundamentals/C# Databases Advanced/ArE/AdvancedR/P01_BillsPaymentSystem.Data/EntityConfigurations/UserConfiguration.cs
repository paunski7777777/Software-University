namespace P01_BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.UserId);

            builder.Property(fn => fn.FirstName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(ln => ln.LastName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}