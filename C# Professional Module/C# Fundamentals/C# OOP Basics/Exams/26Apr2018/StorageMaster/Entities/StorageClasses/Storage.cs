namespace StorageMaster.Entities.StorageClasses
{
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage
    {
        private const string InvalidGarageSlot = "Invalid garage slot!";
        private const string EmptyGarage = "No vehicle in this garage slot!";
        private const string StorageFull = "Storage is full!";
        private const string NoFreeGarageSlot = "No room in garage!";

        private readonly List<Vehicle> garage;
        private readonly List<Product> products;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int GarageSlots { get; set; }
        public IReadOnlyCollection<Vehicle> Garage => this.garage.AsReadOnly();
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        public bool IsFull => this.products.Sum(w => w.Weight) >= this.Capacity;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new List<Vehicle>(vehicles);
            this.products = new List<Product>();
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(InvalidGarageSlot);
            }
            if (!this.garage.Any())
            {
                throw new InvalidOperationException(EmptyGarage);
            }

            var vehicle = this.garage[garageSlot];
            return vehicle;
        }

        //TODO
        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            int garageSlotIndex = 0;

            var vehicle = this.GetVehicle(garageSlot);

            for (int i = 0; i < deliveryLocation.Garage.Count; i++)
            {
                if (garage[i] == null)
                {
                    garage[i] = vehicle;
                    garageSlotIndex = i;
                }
                else
                {
                    throw new InvalidOperationException(NoFreeGarageSlot);
                }
            }

            return garageSlotIndex;
        }

        //TODO
        public int UnloadVehicle(int garageSlot)
        {
            int unloadedProducts = 0;

            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var currentVehicle = this.GetVehicle(garageSlot);

            while (currentVehicle.IsEmpty || this.IsFull)
            {
                var currentProduct = currentVehicle.Unload();
                this.products.Add(currentProduct);
                unloadedProducts++;
            }

            return unloadedProducts;
        }
    }
}
