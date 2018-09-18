using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.StorageClasses
{
    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultGarageSlots = 2;

        public AutomatedWarehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, new List<Truck>() { new Truck() }) { }
    }
}
