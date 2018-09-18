using NUnit.Framework;
public class MissionControllerTests
{
    private MissionController missionController;
    private IArmy army;
    private IWareHouse wareHouse;

    [SetUp]
    public void Initialitze()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
    }
    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        IMission easyMission = new Easy(1);
        string result = string.Empty;

        for (int i = 0; i < 4; i++)
        {
            result = this.missionController.PerformMission(easyMission);
        }

        Assert.IsTrue(result.Contains("declined"));
    }
    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        IMission easyMission = new Easy(0);
        string result = this.missionController.PerformMission(easyMission);

        Assert.IsTrue(result.Contains("completed"));
    }
}
