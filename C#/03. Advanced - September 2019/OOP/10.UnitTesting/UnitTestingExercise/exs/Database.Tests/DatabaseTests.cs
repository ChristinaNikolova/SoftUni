using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(new int[15]);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.database);
        }

        [Test]
        public void CheckIfCountPropWorksCorrectly()
        {
            int expectedResult = 15;
            int actualResult = this.database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddCommandWorksCorrectlyWithValidInput()
        {
            this.database.Add(16);

            int expectedResult = 16;
            int actualResult = this.database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAddCommandThrowsExByAdding17Element()
        {
            this.database.Add(16);

            Assert.Throws<InvalidOperationException>(() =>
            this.database.Add(17));
        }

        [Test]
        public void CheckIfRemoveCommandWorksCorrectlyWithValidInput()
        {
            this.database.Remove();

            int expectedResult = 14;
            int actualResult = this.database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfRemoveCommandThrowsExByRemovingNonExistingElement()
        {
            for (int i = 0; i < 15; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            this.database.Remove());
        }

        [Test]
        public void CheckIfFetchCommandWorksCorrectly()
        {
            int[] expectedResult = new int[15];
            int[] actualResult = this.database.Fetch();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}