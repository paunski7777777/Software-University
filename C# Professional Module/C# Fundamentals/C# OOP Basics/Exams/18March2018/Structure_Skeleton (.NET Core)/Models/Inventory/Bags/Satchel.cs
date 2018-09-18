namespace DungeonsAndCodeWizards.Models.Items
{
    public class Satchel : Bag
    {
        private const int DefaultSatchelCapacity = 20;

        public Satchel()
            : base(DefaultSatchelCapacity)
        {

        }
    }
}
