namespace _04Elevator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = people / capacity;

            if (people % capacity == 0)
            {
                Console.WriteLine(courses);
            }
            else
            {
                courses++;
                Console.WriteLine(courses);
            }
        }
    }
}