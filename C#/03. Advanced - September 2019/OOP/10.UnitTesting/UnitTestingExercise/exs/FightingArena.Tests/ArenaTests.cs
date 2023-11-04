//using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior first;
        private Warrior second;

        [SetUp]
        public void Setup()
        {
            this.first = new Warrior("Misheto", 50, 100);
            this.second = new Warrior("Plamen", 50, 100);

            this.arena = new Arena();
            this.arena.Enroll(this.first);
            this.arena.Enroll(this.second);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena);
        }

        [Test]
        public void CheckIfWarriorCollectionIsReadOnlyCollection()
        {
            IReadOnlyCollection<Warrior> warriors = this.arena.Warriors;

            Assert.IsTrue(warriors is IReadOnlyCollection<Warrior>);
        }

        [Test]
        public void CheckIfCountPropWorksCorrectly()
        {
            int expectedResult = 2;
            int actualResult = this.arena.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfEnrollCommandWorksCorrectlyWithValidInput()
        {
            this.arena.Enroll(new Warrior("Hrisi", 50, 100));

            int expectedResult = 3;
            int actualResult = this.arena.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfEnrollCommandThrowsExByExistingInput()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.arena.Enroll(this.first));
        }

        [Test]
        public void CheckIfFightCommandWorksCorrectlyWithValidInput()
        {
            this.arena.Fight(this.first.Name, this.second.Name);

            int expectedResultFirst = 50;
            int actualResultFirst = this.first.HP;

            int expectedResultSecond = 50;
            int actualResultSecond = this.second.HP;

            Assert.AreEqual(expectedResultFirst, actualResultFirst);
            Assert.AreEqual(expectedResultSecond, actualResultSecond);
        }

        [Test]
        public void CheckIfFightCommandThrowsExByNullInputAttacker()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.arena.Fight(null, this.second.Name));
        }

        [Test]
        public void CheckIfFightCommandThrowsExByNullInputDefender()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.arena.Fight(this.first.Name, null));
        }
    }
}
