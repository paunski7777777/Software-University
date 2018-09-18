using NUnit.Framework;
using System;
public class PersonTests
{
    [Test]
    public void ConstructorInitializationWorks()
    {
        var person = new Person("Pesho", 123456789);
        
        Assert.AreNotEqual(null, person);
        Assert.AreEqual("Pesho", person.Username);
        Assert.AreEqual(123456789, person.Id);
    }
}