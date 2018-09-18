// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SetControllerTests
    {
        private SetController setController;
        private IStage stage;

        [SetUp]
        public void Initialize()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

        [Test]
        public void TestPerformSets()
        {

        }
    }
}