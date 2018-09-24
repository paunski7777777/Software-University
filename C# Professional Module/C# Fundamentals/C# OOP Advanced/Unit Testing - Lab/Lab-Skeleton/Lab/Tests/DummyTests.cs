using NUnit.Framework;
public class DummyTests
{
    private Dummy dummy;
    private const int dummyHealth = 20;
    private const int dummyExperience = 20;

    [SetUp]
    public void InitializeDummy()
    {
        this.dummy = new Dummy(dummyHealth, dummyExperience);
    }

    [Test]
    public void DummyLosesHealthAfterAttack()
    {
        this.dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(15));
    }

    [Test]
    public void DummyIsDeadAfterAttack()
    {
        this.dummy.TakeAttack(20);

        Assert
            .That(() => dummy.TakeAttack(20),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        this.dummy.TakeAttack(20);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(dummyExperience));
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        this.dummy.TakeAttack(10);

        Assert.
            That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
