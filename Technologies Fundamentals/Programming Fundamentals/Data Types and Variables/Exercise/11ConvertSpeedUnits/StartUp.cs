namespace _11ConvertSpeedUnits
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            float meters = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float hourTime = hours + minutes / 60.0f + seconds / 3600.0f;
            float kmPh = (meters / 1000.0f) / hourTime;
            float mPs = kmPh / 3.6f;
            float miPs = (meters / 1609.0f) / hourTime;

            Console.WriteLine(mPs);
            Console.WriteLine(kmPh);
            Console.WriteLine(miPs);
        }
    }
}