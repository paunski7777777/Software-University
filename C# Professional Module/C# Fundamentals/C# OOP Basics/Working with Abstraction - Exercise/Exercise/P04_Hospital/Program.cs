using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int rooms = 0; rooms < 20; rooms++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool isFree = departments[departament].SelectMany(x => x).Count() < 60;
                if (isFree)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);
                    for (int st = 0; st < departments[departament].Count; st++)
                    {
                        if (departments[departament][st].Count < 3)
                        {
                            room = st;
                            break;
                        }
                    }
                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split();

                if (tokens.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[tokens[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (tokens.Length == 2 && int.TryParse(tokens[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[tokens[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[tokens[0] + tokens[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
