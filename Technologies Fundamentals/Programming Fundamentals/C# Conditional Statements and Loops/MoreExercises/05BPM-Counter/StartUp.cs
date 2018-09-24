namespace _05BPM_Counter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int bpm = int.Parse(Console.ReadLine());
            int nob = int.Parse(Console.ReadLine());

            double bar = Math.Round((nob / 4.0), 1);

            double seconds = (nob * 60.0) / bpm;
            int minutes = (int)seconds / 60;
            seconds -= minutes * 60;

            Console.WriteLine($"{bar} bars - {minutes}m {Math.Floor(seconds)}s");
        }
    }
}