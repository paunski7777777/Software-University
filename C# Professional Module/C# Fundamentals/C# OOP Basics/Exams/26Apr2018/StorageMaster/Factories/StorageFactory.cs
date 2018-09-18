namespace StorageMaster.Factories
{
    using StorageMaster.Entities.StorageClasses;
    using System;

    public class StorageFactory
    {
        public Storage CreateStorage(string storageType, string name)
        {
            Storage storage = null;

            switch (storageType)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}
