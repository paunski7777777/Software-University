using System;
using System.Collections.Generic;
using System.Linq;

class Hospital
{
    static void Main()
    {
        var departaments = new Dictionary<string, List<string>>();
        var doctors = new Dictionary<string, List<string>>();

        string input;
        while ((input = Console.ReadLine()) != "Output")
        {
            string[] tokens = input.Split();

            string departament = tokens[0];
            string doctor = tokens[1] + " " + tokens[2];
            string patient = tokens[3];

            if (!departaments.ContainsKey(departament))
            {
                departaments.Add(departament, new List<string>());
            }
            departaments[departament].Add(patient);

            if (!doctors.ContainsKey(doctor))
            {
                doctors.Add(doctor, new List<string>());
            }
            doctors[doctor].Add(patient);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();

            if (tokens.Length == 1)
            {
                foreach (var patient in departaments[input])
                {
                    Console.WriteLine(patient);
                }
            }

            else
            {
                int room;
                if (int.TryParse(tokens[1], out room))
                {
                    var skip = 3 * (room - 1);

                    foreach (var patient in departaments[tokens[0]].Skip(skip).Take(3).OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }

                else
                {
                    foreach (var patient in doctors[input].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}

