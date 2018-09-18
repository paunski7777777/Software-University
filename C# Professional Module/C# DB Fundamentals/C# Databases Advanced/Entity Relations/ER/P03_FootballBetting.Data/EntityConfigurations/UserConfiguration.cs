namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(pk => pk.UserId);

            builder.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(70)
                .IsRequired();

            builder.Property(n => n.Name)
                .HasMaxLength(50);
        }
    }
}