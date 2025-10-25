let petAdoptionAgency = require("./pet-adoption-agency");
const expect = require("chai").expect;

describe("Test petAdoptionAgency object", () => {
  describe("Test petAdoptionAgency object", () => {
    it("should have correct keys", () => {
      expect(petAdoptionAgency).to.have.keys([
        "isPetAvailable",
        "getRecommendedPets",
        "adoptPet",
      ]);
    });
  });

  describe("Test isPetAvailable method", () => {
    it("should return correct message when pet is available and vaccinated", () => {
      expect(petAdoptionAgency.isPetAvailable("dog", 10, true)).to.equals(
        "Great! We have 10 vaccinated dog(s) available for adoption at the agency."
      );
    });

    it("should return correct message when pet is available but not vaccinated", () => {
      expect(petAdoptionAgency.isPetAvailable("dog", 10, false)).to.equals(
        "Great! We have 10 dog(s) available for adoption, but they need vaccination."
      );
    });

    it("should return correct message when pets count is equal to 0", () => {
      expect(petAdoptionAgency.isPetAvailable("dog", 0, false)).to.equals(
        "Sorry, there are no dog(s) available for adoption at the agency."
      );
    });

    it("should return correct message when pets count is below 0", () => {
      expect(petAdoptionAgency.isPetAvailable("dog", -1, false)).to.equals(
        "Sorry, there are no dog(s) available for adoption at the agency."
      );
    });

    it("should throw an exeption when pet input is not a string", () => {
      expect(() =>
        petAdoptionAgency.isPetAvailable(["dog"], 1, false)
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when availableCount input is not a number", () => {
      expect(() =>
        petAdoptionAgency.isPetAvailable("dog", "1", false)
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when vaccinated input is not a boolean", () => {
      expect(() =>
        petAdoptionAgency.isPetAvailable("dog", 1, "false")
      ).to.throws("Invalid input");
    });
  });

  describe("Test getRecommendedPets method", () => {
    const petList = [
      {
        name: "Pesho",
        traits: "black",
      },
      {
        name: "Gosho",
        traits: "black",
      },
      {
        name: "Mimi",
        traits: "white",
      },
    ];

    it("should return correct message when there are reccomented pets", () => {
      expect(petAdoptionAgency.getRecommendedPets(petList, "black")).to.equals(
        "Recommended pets with the desired traits (black): Pesho, Gosho"
      );
      expect(petAdoptionAgency.getRecommendedPets(petList, "white")).to.equals(
        "Recommended pets with the desired traits (white): Mimi"
      );
    });

    it("should return correct message when there are not reccomented pets", () => {
      expect(petAdoptionAgency.getRecommendedPets(petList, "grey")).to.equals(
        "Sorry, we currently have no recommended pets with the desired traits: grey."
      );
    });

    it("should throw an exeption when petList input is not an array", () => {
      expect(() =>
        petAdoptionAgency.getRecommendedPets("Pesho", "grey")
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when desiredTraits input is not a string", () => {
      expect(() =>
        petAdoptionAgency.getRecommendedPets(petList, ["grey"])
      ).to.throws("Invalid input");
    });
  });

  describe("Test adoptPet method", () => {
    it("should return correct message when pet is adopted", () => {
      expect(petAdoptionAgency.adoptPet("dog", "Pesho")).to.equals(
        "Congratulations, Pesho! You have adopted dog from the agency. Enjoy your time with your new furry friend!"
      );
    });

    it("should throw an exeption when pet input is not a string ", () => {
      expect(() => petAdoptionAgency.adoptPet(["dog"], "Pesho")).to.throws(
        "Invalid input"
      );
    });

    it("should throw an exeption when adopterName input is not a string ", () => {
      expect(() => petAdoptionAgency.adoptPet("dog", ["Pesho"])).to.throws(
        "Invalid input"
      );
    });
  });
});
