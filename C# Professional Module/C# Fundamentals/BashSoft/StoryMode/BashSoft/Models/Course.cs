namespace BashSoft.Models
{
    using System.Collections.Generic;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class Course : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public Course(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName => this.studentsByName;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);
        public override string ToString() => this.Name;

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}