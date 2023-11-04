using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("VW", "Golf", 12, 12);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.car);
        }

        [Test]
        public void CheckIfMakePropWorksCorrectly()
        {
            string expectedResult = "VW";
            string actualResult = this.car.Make;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfMakePropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(null, "Golf", 12, 12));
        }

        [Test]
        public void CheckIfMakePropThrowsExByEmptyStringInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car(string.Empty, "Golf", 12, 12));
        }

        [Test]
        public void CheckIfModelPropWorksCorrectly()
        {
            string expectedResult = "Golf";
            string actualResult = this.car.Model;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfModelPropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("VW", null, 12, 12));
        }

        [Test]
        public void CheckIfModelPropThrowsExByEmptyStringInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("VW", string.Empty, 12, 12));
        }

        [Test]
        public void CheckIfFuelConsumptionPropWorksCorrectly()
        {
            double expectedResult = 12;
            double actualResult = this.car.FuelConsumption;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfFuelConsumptionPropThrowsExByZeroInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("VW", "Golf", 0, 12));
        }

        [Test]
        public void CheckIfFuelConsumptionPropThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("VW", "Golf", -12, 12));
        }

        [Test]
        public void CheckIfFuelAmountPropWorksCorrectly()
        {
            double expectedResult = 0;
            double actualResult = this.car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfFuelCapacityPropWorksCorrectly()
        {
            double expectedResult = 12;
            double actualResult = this.car.FuelCapacity;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfFuelCapacityPropThrowsExByZeroInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("VW", "Golf", 12, 0));
        }

        [Test]
        public void CheckIfFuelCapacityPropThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Car("VW", "Golf", 12, -12));
        }

        [Test]
        public void CheckIfRefuelCommandWorksCorrectlyWithValidInput()
        {
            this.car.Refuel(10);

            double expectedResult = 10;
            double actualResult = this.car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfRefuelCommandWorksCorrectlyWithBiggerInput()
        {
            this.car.Refuel(20);

            double expectedResult = 12;
            double actualResult = this.car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfRefuelCommandThrowsExByZeroInput()
        {
            Assert.Throws<ArgumentException>(() =>
            this.car.Refuel(0));
        }

        [Test]
        public void CheckIfRefuelCommandThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            this.car.Refuel(-12));
        }

        [Test]
        public void CheckIfDriveCommandWorksCorrectly()
        {
            this.car.Refuel(10);
            this.car.Drive(5);

            double expectedResult = 9.40;
            double actualResult = this.car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfDriveCommandThrowsExByNotEnoughFuel()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.car.Drive(100));
        }
    }
}