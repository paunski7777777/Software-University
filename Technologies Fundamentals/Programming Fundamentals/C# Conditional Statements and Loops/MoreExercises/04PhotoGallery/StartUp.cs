namespace _04PhotoGallery
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int photos = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int bytes = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double size = 0;
            string sizeP = "";

            if (bytes < 1000)
            {
                size = bytes;
                sizeP = "B";
            }
            else if (bytes > 999 && bytes < 1000000)
            {
                size = bytes / 1000;
                sizeP = "KB";
            }
            else if (bytes > 999999 && bytes < 1000000000)
            {
                size = Math.Round((bytes / 1000000.0), 1);
                sizeP = "MB";
            }

            string orientation = " ";

            if (width > height)
            {
                orientation = "landscape";
            }
            else if (height > width)
            {
                orientation = "portrait";
            }
            else if (width == height)
            {
                orientation = "square";
            }

            Console.WriteLine($"Name: DSC_{photos:d4}.jpg");
            Console.WriteLine($"Date Taken: {day:d2}/{month:d2}/{year} {hours:d2}:{minutes:d2}");
            Console.WriteLine($"Size: {size}{sizeP}");
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}