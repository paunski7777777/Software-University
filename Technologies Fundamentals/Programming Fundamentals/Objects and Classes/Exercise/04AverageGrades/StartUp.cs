namespace _04AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                var grades = input.Skip(1).Select(double.Parse).ToList();

                Student student = new Student
                {
                    Name = name,
                    Grades = grades
                };

                students.Add(student);
            }

            students.Where(g => g.Average >= 5.00)
                    .OrderBy(g => g.Name)
                    .ThenByDescending(g => g.Average)
                    .ToList()
                    .ForEach(g => Console.WriteLine($"{g.Name} -> {g.Average:f2}"));
        }

        public class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double Average => Grades.Average();
        }
    }
}