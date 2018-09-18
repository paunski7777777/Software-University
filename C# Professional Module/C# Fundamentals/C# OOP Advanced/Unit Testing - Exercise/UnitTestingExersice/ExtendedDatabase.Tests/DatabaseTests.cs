using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
public class DatabaseTests
{
    private Database database;

    [SetUp]
    public void Initialize()
    {
        this.database = new Database();
    }

    [Test]
    public void DatabaseInitializationConstructorWithCollectionOfPeople()
    {
        var firstPerson = new Person("First", 111111111);
        var secondPerson = new Person("Second", 222222222);
        var collectionOfPeople = new Person[] { firstPerson, secondPerson };

        this.database = new Database(collectionOfPeople);

        Assert.AreEqual(2, this.database.Count, $"Constructor doesn't work with {typeof(Person)} as parameter");
    }

    [Test]
    public void DatabaseInitializeConstructorWithNullLeadsToEmptyDB()
    {
        Assert.DoesNotThrow(() => this.database = new Database(null));
    }

    [Test]
    public void DatabaseAddPerson()
    {
        var person = new Person("Pesho", 123456789);

        this.database.Add(person);

        Assert.AreEqual(1, this.database.Count, $"Add {typeof(Person)} doesn't work");
    }

    [Test]
    [TestCase(1L, "1L", 1L, "1L")]
    [TestCase(1L, "1L", 10L, "1L")]
    [TestCase(1L, "1L", 1L, "10L")]
    public void CanNotAddPersonWithAlreadyExistingUsernameOrId(long firstId, string firstUsername, long secondId, string secondUsername)
    {
        var firstPerson = new Person(firstUsername, firstId);
        var secondPerson = new Person(secondUsername, secondId);

        this.database.Add(firstPerson);

        Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));
    }

    [Test]
    public void RemovePersonFromDataBase()
    {
        var firstPerson = new Person("First", 1L);
        var secondPerson = new Person("Second", 2L);
        var thirdPerson = new Person("Second", 2);
        this.database.Add(firstPerson);
        this.database.Add(secondPerson);

        this.database.Remove(thirdPerson);
        this.database.Remove(firstPerson);

        Assert.AreEqual(0, this.database.Count, $"Remove {typeof(Person)} doesn't work");
    }

    [Test]
    [TestCase("1L", 1L, "2L", 2L, "3L", 3L, 1L)]
    [TestCase("1L", 1L, "2L", 2L, "3L", 3L, 2L)]
    [TestCase("1L", 1L, "2L", 2L, "3L", 3L, 3L)]
    public void FindById(string firstUsername, long firstId, string secondUsername, long secondId, string thirdUsername, long thirdId, long keyId)
    {
        this.database.Add(new Person(firstUsername, firstId));
        this.database.Add(new Person(secondUsername, secondId));
        this.database.Add(new Person(thirdUsername, thirdId));

        var foundPerson = this.database.Find(keyId);

        Assert.AreEqual(keyId, foundPerson.Id, $"Found {typeof(Person)} by Id is not the desired one");
    }

    [Test]
    [TestCase("1L", 1L, "2L", 2L, "3L", 3L, "1L")]
    [TestCase("1L", 1L, "2L", 2L, "3L", 3L, "2L")]
    [TestCase("1L", 1L, "2L", 2L, "3L", 3L, "3L")]
    public void FindByUsername(string firstUsername, long firstId, string secondUsername, long secondId, string thirdUsername, long thirdId, string keyUsername)
    {
        this.database.Add(new Person(firstUsername, firstId));
        this.database.Add(new Person(secondUsername, secondId));
        this.database.Add(new Person(thirdUsername, thirdId));

        var foundPerson = this.database.Find(keyUsername);

        Assert.AreEqual(keyUsername, foundPerson.Username, $"Found {typeof(Person)} by Username is not the desired one");
    }

    [Test]
    public void CannotFindUnexistentId()
    {
        this.database.Add(new Person("First", 1));

        Assert.Throws<InvalidOperationException>(() => this.database.Find(2));
    }

    [Test]
    public void CannotFindNegativeId()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.database.Find(-1));
    }

    [Test]
    public void CannotFindUnexistentUsername()
    {
        this.database.Add(new Person("First", 1));

        Assert.Throws<InvalidOperationException>(() => this.database.Find("fiRst"));
    }

    [Test]
    public void CannotFindUsernameNull()
    {
        this.database.Add(new Person("First", 1));

        Assert.Throws<ArgumentNullException>(() => this.database.Find(null));
    }
}