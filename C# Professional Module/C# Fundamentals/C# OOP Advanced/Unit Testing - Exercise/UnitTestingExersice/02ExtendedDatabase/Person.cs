public class Person
{
    public string Username { get; set; }
    public long Id { get; set; }
    public Person(string username, long id)
    {
        this.Username = username;
        this.Id = id;
    }
}