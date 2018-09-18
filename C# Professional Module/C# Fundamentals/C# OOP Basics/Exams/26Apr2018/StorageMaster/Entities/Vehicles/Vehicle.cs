namespace StorageMaster.Entities.Vehicles
{
    using StorageMaster.Entities.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle
    {
        private const string VehicleIsFullMessage = "Vehicle is full!";
        private const string VehicleIsEmptyMessage = "No products left in vehicle!";


        private readonly List<Product> trunk;

        public int Capacity { get; set; }
        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();
        public bool IsFull => this.trunk.Sum(w => w.Weight) >= this.Capacity;
        public bool IsEmpty => !this.trunk.Any();

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException(VehicleIsFullMessage);
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException(VehicleIsEmptyMessage);
            }

            var product = this.trunk.Last();
            this.trunk.Remove(product);

            return product;
        }
    }
}
