using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void Initialize()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        var provider1 = new List<string>()
        {
           "Solar", "1", "100"
        };

        var provider2 = new List<string>()
        {
           "Solar", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void BrokenProviderIsRemoved()
    {
        var provider1 = new List<string>()
        {
           "Pressure", "1", "100"
        };

        this.providerController.Register(provider1);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}