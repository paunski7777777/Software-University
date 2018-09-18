using System;
using System.Collections.Generic;
using System.Text;
public class Worker : Human
{
    private const int MIN_WEEK_SALARY = 10;
    private const int MIN_WORK_HOURS_PER_DAY = 1;
    private const int MAX_WORK_HOURS_PER_DAY = 12;
    private const int WORK_DAYS_PER_WEEK = 5;

    private decimal weekSalary;
    private double workHoursPerDay;
    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= MIN_WEEK_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }
    public double WorkHoursePerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < MIN_WORK_HOURS_PER_DAY || value > MAX_WORK_HOURS_PER_DAY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }
    public decimal SalaryPerHour => this.WeekSalary / WORK_DAYS_PER_WEEK / (decimal)WorkHoursePerDay;
    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursePerDay = workHoursPerDay;
    }
    public override string ToString()
    {
        var workerInfo = new StringBuilder();

        workerInfo.AppendLine($"First Name: {this.FirstName}");
        workerInfo.AppendLine($"Last Name: {this.LastName}");
        workerInfo.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        workerInfo.AppendLine($"Hours per day: {this.WorkHoursePerDay:f2}");
        workerInfo.AppendLine($"Salary per hour: {SalaryPerHour:f2}");

        return workerInfo.ToString().TrimEnd();
    }
}
