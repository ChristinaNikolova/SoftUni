using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero first;
    private Hero second;

    [SetUp]
    public void Setup()
    {
        this.first = new Hero("Misheto", 12);
        this.second = new Hero("Plamen", 20);

        this.heroRepository = new HeroRepository();
        this.heroRepository.Create(this.first);
        this.heroRepository.Create(this.second);
    }

    [Test]
    public void CheckIfConstructorWorksCorrectly()
    {
        Assert.IsNotNull(this.heroRepository);
    }

    [Test]
    public void CheckIfCreateCommandWorksCorrectlyWithValidInput()
    {
        string expectedResult = "Successfully added hero Hrisi with level 20";
        string actualResult = this.heroRepository.Create(new Hero("Hrisi", 20));

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CheckIfCreateCommandThrowsExByNullInput()
    {
        Assert.Throws<ArgumentNullException>(() =>
        this.heroRepository.Create(null));
    }

    [Test]
    public void CheckIfCreateCommandThrowsExByExistingInput()
    {
        Assert.Throws<InvalidOperationException>(() =>
        this.heroRepository.Create(this.first));
    }

    [Test]
    public void CheckIfRemoveCommandWorksCorrectlyWithValidInput()
    {
        bool expectedResult = true;
        bool actualResult = this.heroRepository.Remove("Misheto");

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CheckIfRemoveCommandThrowsExByNullInput()
    {
        Assert.Throws<ArgumentNullException>(() =>
        this.heroRepository.Remove(null));
    }

    [Test]
    public void CheckIfRemoveCommandThrowsExByWhiteSpaceInput()
    {
        Assert.Throws<ArgumentNullException>(() =>
        this.heroRepository.Remove("        "));
    }

    [Test]
    public void CheckIfGetHeroWithHighestLevelCommandWorksCorrectly()
    {
        Hero expectedResult = this.second;
        Hero actualResult = this.heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CheckIfGetHeroCommandWorksCorrectly()
    {
        Hero expectedResult = this.second;
        Hero actualResult = this.heroRepository.GetHero("Plamen");

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CheckIfHerosIsReadOnlyCollection()
    {
        IReadOnlyCollection<Hero> heroes = this.heroRepository.Heroes;

        Assert.IsTrue(heroes is IReadOnlyCollection<Hero>);
    }
}