namespace _09MelrahShake
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (pattern.Length > 0)
            {
                int firstIndex = input.IndexOf(pattern);
                int lastIndex = input.LastIndexOf(pattern);

                if (firstIndex >= 0 && lastIndex >= 0 || firstIndex != lastIndex)
                {
                    input = input.Remove(lastIndex, pattern.Length);
                    input = input.Remove(firstIndex, pattern.Length);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    break;
                }

                pattern = pattern.Remove(pattern.Length / 2, 1);
            }

            Console.WriteLine("No shake.");
            Console.WriteLine(input);
        }
    }
}