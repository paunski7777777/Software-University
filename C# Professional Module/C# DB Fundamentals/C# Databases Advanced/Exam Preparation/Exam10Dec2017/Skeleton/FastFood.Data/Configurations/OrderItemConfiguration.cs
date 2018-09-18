namespace FastFood.Data.Configurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(pk => new
            {
                pk.ItemId,
                pk.OrderId
            });
        }
    }
}