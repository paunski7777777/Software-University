namespace _09JumpAround
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool moved = true;
            int sum = 0;
            int currentIndex = 0;

            while (moved)
            {
                moved = false;

                sum += numbers[currentIndex];

                if (currentIndex + numbers[currentIndex] < numbers.Count)
                {
                    currentIndex += numbers[currentIndex];
                    moved = true;
                }
                else if (currentIndex - numbers[currentIndex] >= 0)
                {
                    currentIndex -= numbers[currentIndex];
                    moved = true;
                }
            }

            Console.WriteLine(sum);
        }
    }
}