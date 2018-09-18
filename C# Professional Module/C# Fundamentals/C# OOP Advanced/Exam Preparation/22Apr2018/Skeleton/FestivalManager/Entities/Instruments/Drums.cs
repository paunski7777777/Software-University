namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int Amount = 20;
        protected override int RepairAmount => Amount;
    }
}
