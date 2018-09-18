namespace P01_BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(pk => pk.BankAccountId);

            builder.Property(bn => bn.BankName)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(sc => sc.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Ignore(pmi => pmi.PaymentMethodId);
        }
    }
}