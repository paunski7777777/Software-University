namespace _10StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Town> towns = ReadTownsAndStudents();
            List<Group> groups = DistributeStudentsIntoGroups(towns);
            PrintTownsAndGroups(towns, groups);
        }

        public static void PrintTownsAndGroups(List<Town> towns, List<Group> groups)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");

            foreach (var g in groups.OrderBy(x => x.Town.Name))
            {
                Console.Write($"{g.Town.Name} => ");
                Console.WriteLine($"{string.Join(", ", g.Students.Select(x => x.Email))}");
            }
        }

        public static List<Town> ReadTownsAndStudents()
        {
            string input = Console.ReadLine();

            var towns = new List<Town>();

            while (input != "End")
            {
                if (input.Contains("=>"))
                {
                    string[] tokens = input.Split("=>".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string[] seatsCount = tokens[1].Trim().Split();

                    Town town = new Town();
                    var students = new List<Student>();

                    string townName = tokens[0].Trim();
                    int seats = int.Parse(seatsCount[0].Trim());

                    town.Name = townName;
                    town.SeatsCount = seats;
                    town.Students = students;

                    towns.Add(town);
                }

                else
                {
                    Town town = new Town();
                    Student student = new Student();
                    town.Students = new List<Student>();

                    string[] tokens = input.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string studentName = tokens[0].Trim();
                    string email = tokens[1].Trim();
                    DateTime date = DateTime.ParseExact(tokens[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    student.Name = studentName;
                    student.Email = email;
                    student.RegistrationDate = date;

                    town.Students.Add(student);
                    towns[towns.Count - 1].Students.Add(student);
                }

                input = Console.ReadLine();
            }

            return towns;
        }

        private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            Town town = new Town
            {
                Students = new List<Student>()
            };

            var groups = new List<Group>();

            for (int i = 0; i < towns.Count; i++)
            {
                List<Student> students = towns[i].Students;

                students = towns[i].Students
                                   .OrderBy(d => d.RegistrationDate)
                                   .ThenBy(n => n.Name)
                                   .ThenBy(e => e.Email).ToList();

                while (students.Any())
                {
                    Group group = new Group
                    {
                        Town = towns[i]
                    };

                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount).ToList();

                    groups.Add(group);
                }
            }

            return groups;
        }

        public class Student
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime RegistrationDate { get; set; }
        }

        public class Town
        {
            public string Name { get; set; }
            public int SeatsCount { get; set; }
            public List<Student> Students { get; set; }
        }

        public class Group
        {
            public Town Town { get; set; }
            public List<Student> Students { get; set; }
        }
    }
}