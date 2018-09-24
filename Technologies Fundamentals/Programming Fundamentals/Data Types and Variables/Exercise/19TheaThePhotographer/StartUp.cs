namespace _19TheaThePhotographer
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int pictures = int.Parse(Console.ReadLine());
            int secondsPerPicture = int.Parse(Console.ReadLine());
            int filter = int.Parse(Console.ReadLine());
            int upload = int.Parse(Console.ReadLine());

            double percentage = filter / 100.0;
            int mainPics = (int)Math.Ceiling(pictures * percentage);
            long total = pictures * (long)secondsPerPicture;
            long final = mainPics * (long)upload;

            Console.WriteLine(TimeSpan.FromSeconds(total + final).ToString(new string('d', 1) + @"\:hh\:mm\:ss"));
        }
    }
}