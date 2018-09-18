namespace StorageMaster.Core
{
    using global::StorageMaster.Entities.Products;
    using global::StorageMaster.Entities.StorageClasses;
    using global::StorageMaster.Entities.Vehicles;
    using global::StorageMaster.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;

        private List<Product> productPool;
        private List<Storage> storageRegistry;

        public Vehicle CurrentVehicle { get; set; }

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();

            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            this.productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry.Add(storage);

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);
            this.CurrentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }
        //TODO
        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var product in productNames)
            {
                if (!this.productPool.Any(p => p.GetType().Name == product))
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }

                var currentProduct = this.productPool.Last(p => p.GetType().Name == product);
                this.productPool.Remove(currentProduct);
                this.CurrentVehicle.LoadProduct(currentProduct);
                loadedProductsCount++;

            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.CurrentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var currentStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);

            if (currentStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            currentStorage.SendVehicleTo(sourceGarageSlot, currentStorage);

            return $"Sent {this.CurrentVehicle.GetType().Name} to {destinationName} (slot {sourceGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var currentStorage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            int unloadedProductsCount = currentStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{currentStorage.Products.Count} products at {currentStorage.Name}";

        }

        public string GetStorageStatus(string storageName)
        {
            var currentStorage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            return null;
        }

        public string GetSummary()
        {
            var result = new StringBuilder();

            var ordered = this.storageRegistry.OrderByDescending(p => p.Products.Sum(pr => pr.Price)).ToList();

            foreach (var storage in ordered)
            {
                result.AppendLine($"{storage.Name}:");
                result.AppendLine($"Storage worth: ${storage.Products.Sum(p => p.Price):f2}");
            }

            return result.ToString().TrimEnd();
        }

    }
}
