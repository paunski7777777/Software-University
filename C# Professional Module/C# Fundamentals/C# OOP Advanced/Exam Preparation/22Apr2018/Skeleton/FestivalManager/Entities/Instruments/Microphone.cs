namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int Amount = 80;
        protected override int RepairAmount => Amount;
    }
}
