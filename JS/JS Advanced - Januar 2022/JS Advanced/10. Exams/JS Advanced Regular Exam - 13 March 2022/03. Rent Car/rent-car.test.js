const rentCar = require("./rent-car");
const expect = require("chai").expect;

describe("Test rentCar object", () => {
  describe("Test rentCar object", () => {
    it("should have correct keys", () => {
      expect(rentCar).to.have.keys([
        "searchCar",
        "calculatePriceOfCar",
        "checkBudget",
      ]);
    });
  });

  describe("Test searchCar method", () => {
    it("should return correct message when model is present in the shop", () => {
      expect(rentCar.searchCar(["BMV", "VW", "Audi", "BMV"], "BMV")).to.equals(
        "There is 2 car of model BMV in the catalog!"
      );
    });

    it("should throw an expection when no shop found", () => {
      expect(() =>
        rentCar.searchCar(["VW", "Audi", "BMV"], "Toyota")
      ).to.throws("There are no such models in the catalog!");
    });

    it("should throw an expection when shop is not an array", () => {
      expect(() => rentCar.searchCar("test", "Toyota")).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an expection when model is not a string", () => {
      expect(() =>
        rentCar.searchCar(["VW", "Audi", "BMV"], { car: "Toyota" })
      ).to.throws("Invalid input!");
    });
  });

  describe("Test calculatePriceOfCar method", () => {
    it("should return correct message when correct price", () => {
      expect(rentCar.calculatePriceOfCar("Volkswagen", 15)).to.equals(
        "You choose Volkswagen and it will cost $300!"
      );
    });

    it("should throw an exeption when model does not exist", () => {
      expect(() => rentCar.calculatePriceOfCar("VW", 15)).to.throws(
        "No such model in the catalog!"
      );
    });

    it("should throw an exeption when model is not a string", () => {
      expect(() => rentCar.calculatePriceOfCar({ car: "VW" }, 15)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an exeption when day is not an integer", () => {
      expect(() => rentCar.calculatePriceOfCar("Audi", 15.5)).to.throws(
        "Invalid input!"
      );
    });
  });

  describe("Test checkBudget method", () => {
    it("should return correct message when budget is enought", () => {
      expect(rentCar.checkBudget(10, 15, 2000)).to.equals("You rent a car!");
      expect(rentCar.checkBudget(10, 15, 150)).to.equals("You rent a car!");
    });

    it("should return correct message when budget is not enought", () => {
      expect(rentCar.checkBudget(10, 15, 149)).to.equals(
        "You need a bigger budget!"
      );
    });

    it("should throw an exeption when costPerDay is not an integer", () => {
      expect(() => rentCar.checkBudget("10", 15, 149)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an exeption when days is not an integer", () => {
      expect(() => rentCar.checkBudget(10, "15", 149)).to.throws(
        "Invalid input!"
      );
    });

    it("should throw an exeption when budget is not an integer", () => {
      expect(() => rentCar.checkBudget(10, 15, "149")).to.throws(
        "Invalid input!"
      );
    });
  });
});
