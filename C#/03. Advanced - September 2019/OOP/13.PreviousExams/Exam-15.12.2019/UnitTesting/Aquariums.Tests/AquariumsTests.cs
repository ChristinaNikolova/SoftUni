namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        private Fish first;
        private Fish second;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            this.first = new Fish("Misheto");
            this.second = new Fish("Plamen");

            this.aquarium = new Aquarium("Family", 3);
            this.aquarium.Add(this.first);
            this.aquarium.Add(this.second);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.aquarium);
        }

        [Test]
        public void CheckIfNamePropWorksCorrectly()
        {
            string exRe = "Family";
            string acRe = this.aquarium.Name;

            Assert.AreEqual(exRe, acRe);
        }

        [Test]
        public void CheckIfNamePropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Aquarium(null, 3));
        }

        [Test]
        public void CheckIfNamePropThrowsExByEmptyInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Aquarium(string.Empty, 3));
        }

        [Test]
        public void CheckIfCapacityPropWorksCorrectly()
        {
            int exRe = 3;
            int acRe = this.aquarium.Capacity;

            Assert.AreEqual(exRe, acRe);
        }

        [Test]
        public void CheckIfNamePropThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Aquarium("Family", -3));
        }

        [Test]
        public void CheckIfCountPropWorksCorrectly()
        {
            int exRe = 2;
            int acRe = this.aquarium.Count;

            Assert.AreEqual(exRe, acRe);
        }

        [Test]
        public void CheckIfAddCommandWorksCorrectly()
        {
            this.aquarium.Add(new Fish("Hrisi"));

            int exRe = 3;
            int acRe = this.aquarium.Count;

            Assert.AreEqual(exRe, acRe);
        }

        [Test]
        public void CheckIfAddCommandThrowsExByFullCapacity()
        {
            this.aquarium.Add(new Fish("Hrisi"));

            Assert.Throws<InvalidOperationException>(() =>
            this.aquarium.Add(new Fish("Oskarcho")));
        }

        [Test]
        public void CheckIfRemoveCommandWorksCorrectly()
        {
            this.aquarium.RemoveFish("Plamen");

            int exRe = 1;
            int acRe = this.aquarium.Count;

            Assert.AreEqual(exRe, acRe);
        }

        [Test]
        public void CheckIfRemoveCommandThrowsExByInvalidFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.aquarium.RemoveFish("Hrisi"));
        }

        [Test]
        public void CheckIfSellFisgCommandTrosEx()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.aquarium.SellFish("Hrisi"));
        }

        [Test]
        public void CheckIfSellCommandWorksCorrectly()
        {
            Fish exRe = this.second;
            Fish acRe = this.aquarium.SellFish("Plamen");


            bool exReBool = false;
            bool acReBool = this.second.Available;

            Assert.AreEqual(exRe, acRe);
            Assert.AreEqual(exReBool, acReBool);
        }

        [Test]
        public void CheckIfReportCommandWorksCorrectly()
        {
            List<Fish> fishes = new List<Fish>() { this.first, this.second };

            
            string exRe = $"Fish available at {aquarium.Name}: {string.Join(", ",fishes.Select(x=>x.Name))}";
            //Fish available at Family: Misheto, Plamen
            string acRe = this.aquarium.Report();


            Assert.AreEqual(exRe, acRe);
        }
    }
}
