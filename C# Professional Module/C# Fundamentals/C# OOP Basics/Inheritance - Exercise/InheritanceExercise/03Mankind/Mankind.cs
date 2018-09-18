using System;
public class Mankind
{
    public static void Main()
    {
        try
        {
            Student student = CreateStudent();
            Worker worker = CreateWorker();

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static Student CreateStudent()
    {
        string[] studentInfo = Console.ReadLine().Split();
        string studentFistName = studentInfo[0];
        string studentLastName = studentInfo[1];
        string facultyNumber = studentInfo[2];
        Student student = new Student(studentFistName, studentLastName, facultyNumber);
        return student;
    }

    private static Worker CreateWorker()
    {
        string[] workerInfo = Console.ReadLine().Split();
        string workerFistName = workerInfo[0];
        string workerLastName = workerInfo[1];
        decimal weekSalary = decimal.Parse(workerInfo[2]);
        double hoursPerDay = double.Parse(workerInfo[3]);
        Worker worker = new Worker(workerFistName, workerLastName, weekSalary, hoursPerDay);
        return worker;
    }
}

