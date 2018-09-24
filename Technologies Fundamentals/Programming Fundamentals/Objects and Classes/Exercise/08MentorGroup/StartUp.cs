namespace _08MentorGroup
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class StartUp
    {
        public const string Format = "dd/MM/yyyy";

        public static void Main()
        {
            Dictionary<string, Student> students = AddStudents();
            AddComments(students);
            PrintResults(students);
        }

        public static void PrintResults(Dictionary<string, Student> students)
        {
            foreach (var s in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(s.Key);
                Console.WriteLine("Comments:");
                if (s.Value.Comments.Count > 0)
                {
                    Console.WriteLine($"- {string.Join("\n- ", s.Value.Comments)}");
                }

                Console.WriteLine("Dates attended:");

                if (s.Value.Attendency.Count > 0)
                {
                    foreach (var d in s.Value.Attendency.OrderBy(x => x.Date))
                    {
                        Console.WriteLine($"-- {d:dd/MM/yyyy}");
                    }
                }
            }
        }

        public static void AddComments(Dictionary<string, Student> students)
        {
            string input = Console.ReadLine();

            while (input != "end of comments")
            {
                string[] input1 = input.Split('-');

                string name = input1[0];

                if (!students.ContainsKey(name))
                {
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    List<string> comments = new List<string>();
                    comments.Add(input1[1]);
                    students[name].Comments.AddRange(comments);
                }

                input = Console.ReadLine();
            }
        }

        public static Dictionary<string, Student> AddStudents()
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            string input = Console.ReadLine();

            while (input != "end of dates")
            {
                string[] input1 = input.Split();

                string name = input1[0];

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new Student());
                    students[name].Attendency = new List<DateTime>();
                    students[name].Comments = new List<string>();
                    students[name].Name = name;
                }

                if (input1.Length < 2)
                {
                    input = Console.ReadLine();
                    continue;
                }

                else
                {
                    List<DateTime> dates = input1[1]
                                           .Split(',')
                                           .Select(x => DateTime.ParseExact(x, Format, CultureInfo.InvariantCulture))
                                           .ToList();

                    students[name].Attendency.AddRange(dates);
                }

                input = Console.ReadLine();
            }
            return students;
        }

        public class Student
        {
            public List<string> Comments { get; set; }
            public List<DateTime> Attendency { get; set; }
            public string Name { get; set; }
        }
    }
}