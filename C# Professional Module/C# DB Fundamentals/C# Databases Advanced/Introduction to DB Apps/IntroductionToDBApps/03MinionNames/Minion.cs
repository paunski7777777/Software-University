public class Minion
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Minion(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}