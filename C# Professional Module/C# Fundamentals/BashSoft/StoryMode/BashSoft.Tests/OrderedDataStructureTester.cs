namespace BashSoft.Tests
{
    using BashSoft.Contracts;
    using BashSoft.DataStructures;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void Initialize()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.That(() => this.names.Add(null),
                Throws.ArgumentNullException);
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            var namesCollection = new string[] { "Balkan", "Georgi", "Rosen" };

            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Rosen",
                "Georgi",
                "Balkan"
            };

            Assert.That(namesCollection, Is.EqualTo(this.names));
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("Gosho");
            }

            Assert.IsTrue(this.names.Size == 17);
            Assert.IsTrue(this.names.Capacity != 16);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var list = new List<string> { "pepi", "mepi" };
            this.names.AddAll(list);

            Assert.IsTrue(this.names.Size == 2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            var list = new List<string> { "gogi", null };

            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(list));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            var result = new List<string> { "Ale", "Male" };
            var list = new List<string> { "Male", "Ale" };

            this.names.AddAll(list);

            Assert.That(result, Is.EqualTo(this.names));
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Ceco");
            Assert.AreEqual(1, this.names.Size);

            this.names.Remove("Ceco");
            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Nasko");
            Assert.IsTrue(this.names.Any(n => n == "Ivan"));

            this.names.Remove("Ivan");
            Assert.IsFalse(this.names.Any(n => n == "Ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            this.names.Add("Bojkata");

            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }
        
        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Chocho");
            this.names.Add("Mocho");
            this.names.Add("Ducho");

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Chocho");
            this.names.Add("Mocho");
            this.names.Add("Ducho");

            Assert.AreEqual("Chocho, Ducho, Mocho", this.names.JoinWith(", "));
        }
    }
}
