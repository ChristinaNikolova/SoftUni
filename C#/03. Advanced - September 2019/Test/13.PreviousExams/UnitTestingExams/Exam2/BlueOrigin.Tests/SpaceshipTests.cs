namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;
        private Astronaut first;
        private Astronaut second;

        [SetUp]
        public void Setup()
        {
            this.first = new Astronaut("Misheto", 25);
            this.second = new Astronaut("Plamen", 20);

            this.spaceship = new Spaceship("Family", 3);
            this.spaceship.Add(this.first);
            this.spaceship.Add(this.second);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.spaceship);
        }

        [Test]
        public void CheckIfCountPropWorksCorrectly()
        {
            int expectedResult = 2;
            int actualResult = this.spaceship.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfNamePropWorksCorrectly()
        {
            string expectedResult = "Family";
            string actualResult = this.spaceship.Name;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfNamePropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Spaceship(null, 12));
        }

        [Test]
        public void CheckIfNamePropThrowsExByStringEmptyInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Spaceship(string.Empty, 12));
        }

        [Test]
        public void CheckIfCapacityPropWorksCorrectly()
        {
            int expectedResult = 3;
            int actualResult = this.spaceship.Capacity;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfCapacityPropThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Spaceship("Family", -12));
        }

        [Test]
        public void CheckIfAddCommandWorksCorrectlyWithValidInput()
        {
            this.spaceship.Add(new Astronaut("Hrisi", 19));

            int expectedResult = 3;
            int actualResult = this.spaceship.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddCommandThrowsExByFullCapacity()
        {
            this.spaceship.Add(new Astronaut("Hrisi", 19));

            Assert.Throws<InvalidOperationException>(() =>
            this.spaceship.Add(new Astronaut("Oskarcho", 15)));
        }

        [Test]
        public void CheckIfAddCommandThrowsExByExistingInput()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.spaceship.Add(this.first));
        }

        [Test]
        public void CheckIfRemoveCommandWorksCorrectlyWithValidInput()
        {
            bool expectedResult = true;
            bool actualResult = this.spaceship.Remove("Misheto");

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}