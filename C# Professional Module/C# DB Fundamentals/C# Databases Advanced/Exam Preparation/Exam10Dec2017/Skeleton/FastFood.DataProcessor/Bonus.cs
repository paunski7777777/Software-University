namespace FastFood.DataProcessor
{
    using System;
    using System.Linq;
    using FastFood.Data;

    public static class Bonus
    {
        public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
        {
            var item = context.Items.FirstOrDefault(n => n.Name == itemName);

            if (item == null)
            {
                return $"Item {itemName} not found!";
            }

            var oldPrice = item.Price;

            item.Price = newPrice;

            context.SaveChanges();

            return $"{item.Name} Price updated from ${oldPrice:f2} to ${newPrice:f2}";
        }
    }
}