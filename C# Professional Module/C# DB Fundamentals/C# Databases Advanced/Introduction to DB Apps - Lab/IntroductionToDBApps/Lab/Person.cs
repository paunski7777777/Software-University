public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JobTitle { get; set; }

    public Person(string firstName, string lastName, string jobTitle)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.JobTitle = jobTitle;
    }

    public override string ToString()
    {
        string result = $"{this.FirstName} {this.LastName} is a {this.JobTitle}";
        return result;
    }
}