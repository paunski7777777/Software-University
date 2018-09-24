namespace _08AverageGrades
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // string[] inputFile = File.ReadAllLines("input.txt");
            string[] inputFile2 = File.ReadAllLines("input2.txt");

            var students = new List<Student>();

            for (int i = 1; i < inputFile2.Length; i++)
            {
                string[] input = inputFile2[i].Split();

                Student student = new Student
                {
                    Name = input[0],
                    Grades = input.Skip(1).Select(double.Parse).ToList()
                };

                students.Add(student);
            }

            students = students
                       .Where(g => g.Average >= 5.00)
                       .OrderBy(g => g.Name)
                       .ThenByDescending(g => g.Average)
                       .ToList();

            foreach (var s in students)
            {
                // File.AppendAllText("output.txt", $"{s.Name} -> {s.Average:f2}");
                File.AppendAllText("output2.txt", $"{s.Name} -> {s.Average:f2}");
                // File.AppendAllText("output.txt", Environment.NewLine);
                File.AppendAllText("output2.txt", Environment.NewLine);
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double Average => Grades.Average();
        }
    }
}