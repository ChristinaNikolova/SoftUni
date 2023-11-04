//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Misheto", 50, 100);
        }

        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.warrior);
        }

        [Test]
        public void CheckIfNamePropWorksCorrectly()
        {
            string expectedResult = "Misheto";
            string actualResult = this.warrior.Name;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfNamePropThrowsExByNullInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior(null, 50, 100));
        }

        [Test]
        public void CheckIfNamePropThrowsExByWhiteSpaceInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior("       ", 50, 100));
        }

        [Test]
        public void CheckIfDamagePropWorksCorrectly()
        {
            int expectedResult = 50;
            int actualResult = this.warrior.Damage;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfDamagePropThrowsExByZeroInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior("Misheto", 0, 100));
        }

        [Test]
        public void CheckIfDamagePropThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior("Misheto", -50, 100));
        }

        [Test]
        public void CheckIfHPPropWorksCorrectly()
        {
            int expectedResult = 100;
            int actualResult = this.warrior.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfHPPropThrowsExByNegativeInput()
        {
            Assert.Throws<ArgumentException>(() =>
            new Warrior("Misheto", 50, -100));
        }

        [Test]
        public void CheckIfAttackCommandThrowsExByLowerHpThanMinAttackHPAttacker()
        {
            Warrior attacker = new Warrior("Misheto", 50, 25);
            Warrior defender = new Warrior("Plamen", 20, 100);

            Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(defender));
        }

        [Test]
        public void CheckIfAttackCommandThrowsExByHPEqualToTheMinAttackHPAttacker()
        {
            Warrior attacker = new Warrior("Misheto", 50, 30);
            Warrior defender = new Warrior("Plamen", 20, 100);

            Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(defender));
        }

        [Test]
        public void CheckIfAttackCommandThrowsExByLowerHpThanMinAttackHPDefender()
        {
            Warrior attacker = new Warrior("Misheto", 50, 100);
            Warrior defender = new Warrior("Plamen", 50, 25);

            Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(defender));
        }

        [Test]
        public void CheckIfAttackCommandThrowsExByHPEqualToTheMinAttackHPDefender()
        {
            Warrior attacker = new Warrior("Misheto", 50, 100);
            Warrior defender = new Warrior("Plamen", 50, 30);

            Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(defender));
        }

        [Test]
        public void CheckIfAttackCommandThrowsExByHPLowerThanDefenderDamage()
        {
            Warrior attacker = new Warrior("Misheto", 50, 40);
            Warrior defender = new Warrior("Plamen", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            attacker.Attack(defender));
        }

        [Test]
        public void CheckIfAttackCommandWorksCorrectlyAttacker()
        {
            Warrior attacker = new Warrior("Misheto", 50, 100);
            Warrior defender = new Warrior("Plamen", 50, 100);

            attacker.Attack(defender);

            int expectedResult = 50;
            int actualResult = attacker.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAttackCommandWorksCorrectlyDefender()
        {
            Warrior attacker = new Warrior("Misheto", 50, 100);
            Warrior defender = new Warrior("Plamen", 50, 100);

            attacker.Attack(defender);

            int expectedResult = 50;
            int actualResult = defender.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CheckIfAttackCommandWorksCorrectlyDefenderDeadCase()
        {
            Warrior attacker = new Warrior("Misheto", 50, 100);
            Warrior defender = new Warrior("Plamen", 50, 40);

            attacker.Attack(defender);

            int expectedResult = 0;
            int actualResult = defender.HP;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}