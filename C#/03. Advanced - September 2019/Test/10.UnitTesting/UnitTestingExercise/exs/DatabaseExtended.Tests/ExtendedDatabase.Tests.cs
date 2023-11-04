using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        private Person first;
        private Person second;

        [SetUp]
        public void Setup()
        {
            this.first = new Person(1234, "Misheto");
            this.second = new Person(5678, "Plamen");

            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(new Person[] { this.first, this.second });
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.extendedDatabase);
        }

        [Test]
        public void CheckIfCountPropWorksCorrectly()
        {
            int expectedResult = 2;
            int actualResult = this.extendedDatabase.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddRangeCommandWorksCorrectlyWithValidInput()
        {
            Person[] people = new Person[] { this.first, this.second };

            ExtendedDatabase.ExtendedDatabase data = new ExtendedDatabase.ExtendedDatabase(people);

            int expectedResult = 2;
            int actualResult = data.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddRangeCommandThrowsExByAddingRangeOf17People()
        {
            Person[] people = new Person[17];

            Assert.Throws<ArgumentException>(() =>
            new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void CheckIfAddCommandWorksCorrectlyWithCorrertInput()
        {
            this.extendedDatabase.Add(new Person(9999, "Hrisi"));

            int expectedResult = 3;
            int actualResult = this.extendedDatabase.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddCommandThrowsExByAdding17Element()
        {
            long id = 1;
            string name = "a";

            for (int i = 2; i < 16; i++)
            {
                this.extendedDatabase.Add(new Person(id, name));

                id++;
                name += "a";
            }

            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Add(new Person(9999, "Hrisi")));
        }

        [Test]
        public void CheckIfAddCommandThrowsExByAddingAlreadyExistingUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Add(new Person(9999, "Misheto")));
        }

        [Test]
        public void CheckIfAddCommandThrowsExByAddingAlreadyExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Add(new Person(1234, "Hrisi")));
        }

        [Test]
        public void CheckIfRemoveCommandWorksCorrectly()
        {
            this.extendedDatabase.Remove();

            int expectedResult = 1;
            int actualResult = this.extendedDatabase.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfRemoveCommandThrowsExByRemovingByEmptyArray()
        {
            this.extendedDatabase.Remove();
            this.extendedDatabase.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Remove());
        }

        [Test]
        public void CheckIfFindByUsernameCommandWorksCorrectly()
        {
            Person expectedResult = this.first;
            Person actualResult = this.extendedDatabase.FindByUsername("Misheto");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfFindByUsernameCommandThrowsExByNullInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.extendedDatabase.FindByUsername(null));
        }

        [Test]
        public void CheckIfFindByUsernameCommandThrowsExByEmptyInput()
        {
            Assert.Throws<ArgumentNullException>(() =>
            this.extendedDatabase.FindByUsername(string.Empty));
        }

        [Test]
        public void CheckIfFindByUsernameCommandThrowsExByNonExistingInput()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.FindByUsername("Hrisi"));
        }

        [Test]
        public void CheckIfFindByIdCommandWorksCorrectly()
        {
            Person expectedResult = this.first;
            Person actualResult = this.extendedDatabase.FindById(1234);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfFindByIdCommandThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            this.extendedDatabase.FindById(-1234));
        }

        [Test]
        public void CheckIfFindByIdCommandThrowsExByNonExistingInput()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.FindById(9999));
        }
    }
}