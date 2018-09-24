using Moq;
using NUnit.Framework;
public class HeroTests
{
    [Test]
    public void HeroGainsXPwhenTargetDies()
    {
        var fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(d => d.Health).Returns(0);
        fakeTarget.Setup(d => d.IsDead()).Returns(true);
        fakeTarget.Setup(d => d.GiveExperience()).Returns(20);

        var fakeWeapon = new Mock<IWeapon>();

        var hero = new Hero("Pesho", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(20));
    }
}