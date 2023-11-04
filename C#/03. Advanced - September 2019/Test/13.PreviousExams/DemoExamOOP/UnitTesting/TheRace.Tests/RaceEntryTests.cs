using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitRider first;
        private UnitRider second;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.first = new UnitRider("Misheto", new UnitMotorcycle("Yamaha", 100, 50));
            this.second = new UnitRider("Plamen", new UnitMotorcycle("Yamaha1", 100, 50));

            this.raceEntry.AddRider(this.first);
            this.raceEntry.AddRider(this.second);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.raceEntry);
        }

        [Test]
        public void CheckIfCounterWorksCorrectly()
        {
            int exRe = 2;
            int acRe = this.raceEntry.Counter;

            Assert.AreEqual(exRe, acRe);
        }

        [Test]
        public void CheckIfAddRiderCommandWorksCorrectly()
        {
            string exRe = "Rider Hrisi added in race.";
            string acRe = this.raceEntry.AddRider(new UnitRider("Hrisi", new UnitMotorcycle("qs", 45, 67)));

            int exReCount = 3;
            int acReCount = this.raceEntry.Counter;

            Assert.AreEqual(exRe, acRe);
            Assert.AreEqual(exReCount, acReCount);
        }

        [Test]
        public void CheckIfAddRiderCommandThrowsExByNull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.raceEntry.AddRider(null));
        }

        [Test]
        public void CheckIfAddRiderCommandThrowsExByExistingRider()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.raceEntry.AddRider(this.first));
        }

        [Test]
        public void CheckIfLastCommandThrowsExByExistingRider()
        {
            RaceEntry second = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() =>
            second.CalculateAverageHorsePower());
        }

        [Test]
        public void CheckIfLastCommandCorrect()
        {
            this.raceEntry.AddRider(new UnitRider("Hrisi", new UnitMotorcycle("qs", 45, 67)));

            double exResult = 81.666666666666671;
            double result = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(exResult, result);
        }
    }
}