using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.StorageClasses
{
    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultGarageSlots = 10;

        public Warehouse(string name)
            : base(name, DefaultCapacity, DefaultGarageSlots, new List<Semi>() { new Semi(), new Semi(), new Semi() }) { }
    }
}
