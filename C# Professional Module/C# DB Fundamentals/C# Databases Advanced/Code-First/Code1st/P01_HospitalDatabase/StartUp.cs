namespace P01_HospitalDatabase
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Initializer;

    public class StartUp
    {
        public static void Main()
        {
            var db = new HospitalContext();

            using (db)
            {
                DatabaseInitializer.InitialSeed(db);
            }
        }
    }
}
