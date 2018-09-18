namespace StudentsXML
{
    using StudentsXML.Models;

    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            var serializer = new XmlSerializer(typeof(List<StudentDto>), new XmlRootAttribute("students"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

            var students = GetStudents();

            using (TextWriter writer = new StreamWriter("../../../students.xml"))
            {
                serializer.Serialize(writer, students, namespaces);
            }
        }

        private static List<StudentDto> GetStudents()
        {
            StudentDto student = new StudentDto
            {
                Name = "Ivan Ivanov",
                Gender = "Male",
                BirthDate = "1999/12/23",
                PhoneNumber = "0000000000",
                Email = "ivan.ivanov@abv.bg",
                University = "Software University",
                Specialty = "C# Web Developer",
                FacultyNumber = "1235435767",
                Exams = new ExamsSection
                {
                    Exams = new List<ExamDto>
                    {
                        new ExamDto
                        {
                            Name = "Programming Basics",
                            DateTaken = "2017/01/01",
                            Grade = 6.0
                        }
                    }
                }
            };

            return new List<StudentDto> { student };
        }
    }
}