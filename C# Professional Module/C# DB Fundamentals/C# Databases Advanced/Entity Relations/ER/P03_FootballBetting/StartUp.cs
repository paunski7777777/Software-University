using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new FootballBettingContext();

            using (db)
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
