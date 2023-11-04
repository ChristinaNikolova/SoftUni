namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            this.phone = new Phone("Samsung", "Galaxy S9+");

            this.phone.AddContact("Misheto", "0886758334");
            this.phone.AddContact("Plamen", "0883597509");
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.phone);
        }

        [Test]
        public void CheckIfMakePropWorksCorrectlyWithValidInput()
        {
            string expectedResult = "Samsung";
            string actualResult = this.phone.Make;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfMakePropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Phone(null, "Galaxy S9+"));
        }

        [Test]
        public void CheckIfMakePropThrowsExByEmptyStringInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Phone(string.Empty, "Galaxy S9+"));
        }

        [Test]
        public void CheckIfModelPropWorksCorrectlyWithValidInput()
        {
            string expectedResult = "Galaxy S9+";
            string actualResult = this.phone.Model;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfModelPropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Phone("Samsung", null));
        }

        [Test]
        public void CheckIfModelPropThrowsExByEmptyStringInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Phone("Samsung", string.Empty));
        }

        [Test]
        public void CheckIfCountPropWorksCorrectly()
        {
            int expectedResult = 2;
            int actualResult = this.phone.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddContactCommandWorksCorrectlyWithValidInput()
        {
            this.phone.AddContact("Hrisi", "0883331575");

            int expectedResult = 3;
            int actualResult = this.phone.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddContactCommandThrowsExByExistingInput()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.phone.AddContact("Misheto", "0886758334"));
        }

        [Test]
        public void CheckIfCallCommandWorksCorrectlyWithValidInput()
        {
            string expectedResult = "Calling Misheto - 0886758334...";
            string actualResult = this.phone.Call("Misheto");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfCallCommandThrowsExByNonExistingInput()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.phone.Call("Hrisi"));
        }
    }
}