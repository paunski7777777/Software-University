namespace FestivalManager.Entities.Sets
{
    using System;
    public class Short : Set
    {
        private const int max = 15;
        public Short(string name)
            : base(name, new TimeSpan(0, max, 0))
        {

        }
    }
}
