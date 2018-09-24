namespace _13DecryptingMessage
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string message = string.Empty;

            for (int i = 0; i < n; i++)
            {
                message += ((char)(char.Parse(Console.ReadLine()) + key)).ToString();

            }

            Console.WriteLine(message);
        }
    }
}