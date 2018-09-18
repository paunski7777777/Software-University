namespace StorageMaster.Entities.Vehicles
{
    public class Van : Vehicle
    {
        private const int DefaultCapacity = 2;

        public Van()
            : base(DefaultCapacity) { }
    }
}
