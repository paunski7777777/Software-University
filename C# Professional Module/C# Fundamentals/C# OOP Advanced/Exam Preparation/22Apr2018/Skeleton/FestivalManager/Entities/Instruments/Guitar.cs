namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int Amount = 60;
        protected override int RepairAmount => Amount;
    }
}
