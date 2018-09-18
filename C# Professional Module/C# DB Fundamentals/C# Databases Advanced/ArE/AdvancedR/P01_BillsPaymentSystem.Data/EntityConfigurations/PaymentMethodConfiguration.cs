namespace P01_BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pk => pk.PaymentMethodId);

            builder.HasIndex(i => new
            {
                i.UserId,
                i.CreditCardId,
                i.BankAccountId
            })
            .IsUnique();

            builder.HasOne(u => u.User)
                .WithMany(pm => pm.PaymentMethods)
                .HasForeignKey(fk => fk.UserId);

            builder.HasOne(ba => ba.BankAccount)
                .WithOne(pm => pm.PaymentMethod)
                .HasForeignKey<PaymentMethod>(fk => fk.BankAccountId);

            builder.HasOne(cc => cc.CreditCard)
                .WithOne(pm => pm.PaymentMethod)
                .HasForeignKey<PaymentMethod>(fk => fk.CreditCardId);
        }
    }
}