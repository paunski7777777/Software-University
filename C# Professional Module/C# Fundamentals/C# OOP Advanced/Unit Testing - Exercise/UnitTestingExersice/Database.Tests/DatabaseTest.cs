using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

public class DatabaseTest
{
    private Database database;
    private const int capacity = 16;

    [SetUp]
    public void Initialize()
    {
        this.database = new Database();
    }

    [Test]
    public void MaxCapacityReached()
    {
        Assert
            .That(() => database = new Database(new int[capacity + 1]),
            Throws.InvalidOperationException.With.Message.EqualTo("Max capacity reached!"));
    }

    [Test]
    public void NoElementsInArray()
    {
        Assert
            .That(() => database.Remove(),
            Throws.InvalidOperationException.With.Message.EqualTo("Array is empty! Cannot remove items!"));
    }

    [Test]
    public void AddElementsToArray()
    {
        this.database.Add(1);
        int firstIndex = database.Index;

        this.database.Add(1);
        int secondIndex = database.Index;

        Assert.AreEqual(firstIndex, secondIndex - 1);
    }

    [Test]
    public void FetchArray()
    {
        this.database = new Database(1, 2, 3);
        var arrayTest = new int[] { 1, 2, 3 };
        Assert.AreEqual(database.Fetch(), arrayTest);

        this.database.Remove();
        var arrayTestSecond = new int[] { 1, 2 };
        Assert.AreEqual(database.Fetch(), arrayTestSecond);

        this.database.Add(4);
        var arrayTestThird = new int[] { 1, 2, 4 };
        Assert.AreEqual(database.Fetch(), arrayTestThird);
    }

    [Test]
    [TestCase(1, 2)]
    public void ConstructorParametersCheck(int firstNumber, int secondNumber)
    {
        this.database = new Database(firstNumber, secondNumber);
        var databaseContent = this.database.Fetch();

        Assert.AreEqual(firstNumber, databaseContent[0]);
        Assert.AreEqual(secondNumber, databaseContent[1]);
    }

    //[Test]
    //public void TestValidConstructor()
    //{
    //    int[] values = new int[] { 1, 2, 3, 4 };

    //    this.database = new Database(values);

    //    FieldInfo field = typeof(Database)
    //        .GetFields(BindingFlags.Instance | BindingFlags.Public)
    //        .First(f => f.FieldType == typeof(int[]));

    //    int[] actualValues = (int[])field.GetValue(this.database.Fetch());

    //    Assert.That(actualValues, Is.EquivalentTo(values));
    //}
}