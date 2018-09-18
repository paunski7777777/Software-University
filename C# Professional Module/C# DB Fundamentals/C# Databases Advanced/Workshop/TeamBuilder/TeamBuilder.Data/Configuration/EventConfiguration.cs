namespace TeamBuilder.Data.Configuration
{
    using TeamBuilder.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(n => n.Name)
                   .IsUnicode();

            builder.Property(d => d.Description)
                   .IsUnicode();
        }
    }
}