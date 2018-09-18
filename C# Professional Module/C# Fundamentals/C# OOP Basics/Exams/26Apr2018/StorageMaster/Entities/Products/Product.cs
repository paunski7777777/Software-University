namespace StorageMaster.Entities.Products
{
    using System;

    public abstract class Product
    {
        private const string ErrorPrice = "Price cannot be negative!";

        private double price;

        public double Price
        {
            get { return price; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(ErrorPrice);
                }
                price = value;
            }
        }
        public double Weight { get; set; }

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
    }
}
