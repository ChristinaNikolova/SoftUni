let findNewApartment = require("./find-apartment");
const expect = require("chai").expect;

describe("Test findNewApartment object", () => {
  describe("Test findNewApartment object", () => {
    it("should have correct keys", () => {
      expect(findNewApartment).to.have.keys([
        "isGoodLocation",
        "isLargeEnough",
        "isItAffordable",
      ]);
    });
  });

  describe("Test isGoodLocation method", () => {
    it("should return correct message when city is not suitable", () => {
      expect(findNewApartment.isGoodLocation("Burgas", false)).to.equals(
        "This location is not suitable for you."
      );
    });

    it("should return correct message when there is a near transport", () => {
      expect(findNewApartment.isGoodLocation("Varna", true)).to.equals(
        "You can go on home tour!"
      );
      expect(findNewApartment.isGoodLocation("Sofia", true)).to.equals(
        "You can go on home tour!"
      );
      expect(findNewApartment.isGoodLocation("Plovdiv", true)).to.equals(
        "You can go on home tour!"
      );
    });

    it("should return correct message when there is not a near transport", () => {
      expect(findNewApartment.isGoodLocation("Varna", false)).to.equals(
        "There is no public transport in area."
      );
      expect(findNewApartment.isGoodLocation("Sofia", false)).to.equals(
        "There is no public transport in area."
      );
      expect(findNewApartment.isGoodLocation("Plovdiv", false)).to.equals(
        "There is no public transport in area."
      );
    });

    it("should throw an exeption when city input is not a string", () => {
      expect(() => findNewApartment.isGoodLocation(["Varna"], false)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an exeption when nearPublicTransportation input is not a boolean", () => {
      expect(() => findNewApartment.isGoodLocation("Varna", "false")).to.throws(
        "Invalid input!"
      );
    });
  });

  describe("Test isLargeEnough method", () => {
    it("should return correct result", () => {
      expect(
        findNewApartment.isLargeEnough([20, 30, 40, 49, 50, 51, 100, 80], 50)
      ).to.equals("50, 51, 100, 80");
    });

    it("should throw an exeption when apartments input is not an array", () => {
      expect(() =>
        findNewApartment.isLargeEnough("20, 30, 40, 49, 50, 51, 100, 80", 50)
      ).to.throws("Invalid input!");
    });

    it("should throw an exeption when minimalSquareMeters input is not a number", () => {
      expect(() =>
        findNewApartment.isLargeEnough([20, 30, 40, 49, 50, 51, 100, 80], "50")
      ).to.throws("Invalid input!");
    });

    it("should throw an exeption when apartments input length equals 0", () => {
      expect(() => findNewApartment.isLargeEnough([], 50)).to.throws(
        "Invalid input!"
      );
    });
  });

  describe("Test isItAffordable method", () => {
    it("should return correct message when the budget is not enought", () => {
      expect(findNewApartment.isItAffordable(300, 299)).to.equals(
        "You don't have enough money for this house!"
      );
    });

    it("should return correct message when the budget equals the price", () => {
      expect(findNewApartment.isItAffordable(300, 300)).to.equals(
        "You can afford this home!"
      );
    });

    it("should return correct message when the budget above the price", () => {
      expect(findNewApartment.isItAffordable(300, 301)).to.equals(
        "You can afford this home!"
      );
    });

    it("should throw an expetion when price input is not a number", () => {
      expect(() => findNewApartment.isItAffordable("300", 300)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an expetion when budget input is not a number", () => {
      expect(() => findNewApartment.isItAffordable(300, "300")).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an expetion when price input equals 0", () => {
      expect(() => findNewApartment.isItAffordable(0, 300)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an expetion when price input is below 0", () => {
      expect(() => findNewApartment.isItAffordable(-1, 300)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an expetion when budget input equals 0", () => {
      expect(() => findNewApartment.isItAffordable(300, 0)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an expetion when budget input is below 0", () => {
      expect(() => findNewApartment.isItAffordable(300, -1)).to.throws(
        "Invalid input!"
      );
    });
  });
});
