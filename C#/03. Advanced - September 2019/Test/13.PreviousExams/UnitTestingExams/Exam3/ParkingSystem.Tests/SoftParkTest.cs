namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private Car first;
        private Car second;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.first = new Car("VW", "1234");
            this.second = new Car("Toyota", "5678");

            this.softPark = new SoftPark();
            this.softPark.ParkCar("A1", this.first);
            this.softPark.ParkCar("A2", this.second);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.softPark);
        }

        [Test]
        public void CheckIfParkSpotsCountIsCorrect()
        {
            int expectedResult = 12;
            int actualResult = this.softPark.Parking.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfParkingIsReadOnlyDictionary()
        {
            IReadOnlyDictionary<string, Car> parking = this.softPark.Parking;

            Assert.IsTrue(parking is IReadOnlyDictionary<string, Car>);
        }

        [Test]
        public void CheckIfParkCarCommandWorksCorrectlyWithValidInput()
        {
            string expectedResult = $"Car:9999 parked successfully!";
            string actualResult = this.softPark.ParkCar("A3", new Car("Audi", "9999"));

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfParkCarCommandThrowsExByNonExistingParkSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            this.softPark.ParkCar("Z1", new Car("Audi", "9999")));
        }

        [Test]
        public void CheckIfParkCarCommandThrowsExByNotFreeParkSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            this.softPark.ParkCar("A1", new Car("Audi", "9999")));
        }

        [Test]
        public void CheckIfParkCarCommandThrowsExByExistingCarSpot()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.softPark.ParkCar("A3", this.first));
        }

        [Test]
        public void CheckIfRemoveCarCommandWorksCorrectlyWithValidInput()
        {
            string expectedResult = "Remove car:1234 successfully!";
            string actualResult = this.softPark.RemoveCar("A1", this.first);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfRemoveCarCommandThrowsExByNonExistingParkSpot()
        {
            Assert.Throws<ArgumentException>(() =>
            this.softPark.RemoveCar("Z1", this.first));
        }

        [Test]
        public void CheckIfRemoveCarCommandThrowsExByNonExistingCar()
        {
            Assert.Throws<ArgumentException>(() =>
            this.softPark.RemoveCar("A1", this.second));
        }
    }
}