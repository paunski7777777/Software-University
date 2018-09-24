namespace _05ParkingValidation
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> database = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                string command = tokens[0];
                string user = tokens[1];

                if (command == "register")
                {
                    string plate = tokens[2];

                    if (database.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {database[user]}");
                        continue;

                    }
                    if (IsPlateValid(plate))
                    {
                        Console.WriteLine($"ERROR: invalid license plate {plate}");
                        continue;
                    }
                    if (database.ContainsValue(plate))
                    {
                        Console.WriteLine($"ERROR: license plate {plate} is busy");
                        continue;

                    }

                    database[user] = plate;

                    Console.WriteLine($"{user} registered {plate} successfully");
                }
                if (command == "unregister")
                {
                    if (!database.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                        continue;
                    }

                    database.Remove(user);

                    Console.WriteLine($"user {user} unregistered successfully");
                }
            }

            foreach (var d in database)
            {
                Console.WriteLine($"{d.Key} => {d.Value}");
            }
        }

        private static bool IsPlateValid(string plate)
        {
            if (plate.Length != 8)
            {
                return true;
            }

            string firstAndLastTwo = plate.Substring(0, 2) + plate.Substring(6);

            foreach (var ch in firstAndLastTwo)
            {
                if (ch < 'A' || 'Z' < ch)
                {
                    return true;
                }
            }

            string middleFour = plate.Substring(2, 4);

            foreach (var ch in middleFour)
            {
                if (ch < '0' || '9' < ch)
                {
                    return true;
                }
            }

            return false;
        }
    }
}