let chooseYourCar = require("./choose-your-car");
const expect = require("chai").expect;

describe("Test chooseYourCar object", () => {
  describe("Test chooseYourCar object", () => {
    it("should have correct keys", () => {
      expect(chooseYourCar).to.have.keys([
        "choosingType",
        "brandName",
        "carFuelConsumption",
      ]);
    });
  });

  describe("Test choosingType method", () => {
    it("should return correct message when input data is correct and year is before 2010", () => {
      expect(chooseYourCar.choosingType("Sedan", "red", 2009)).to.equals(
        "This Sedan is too old for you, especially with that red color."
      );
    });

    it("should return correct message when input data is correct and year is equal to 2010", () => {
      expect(chooseYourCar.choosingType("Sedan", "red", 2010)).to.equals(
        "This red Sedan meets the requirements, that you have."
      );
    });

    it("should return correct message when input data is correct and year is after 2010", () => {
      expect(chooseYourCar.choosingType("Sedan", "red", 2011)).to.equals(
        "This red Sedan meets the requirements, that you have."
      );
    });

    it("should throw an exeption when type is not Sedan", () => {
      expect(() => chooseYourCar.choosingType("Audi", "red", 2011)).to.throws(
        "This type of car is not what you are looking for."
      );
    });

    it("should throw an exeption when year is before 1900", () => {
      expect(() => chooseYourCar.choosingType("Sedan", "red", 1899)).to.throws(
        "Invalid Year!"
      );
    });

    it("should throw an exeption when year is after 2023", () => {
      expect(() => chooseYourCar.choosingType("Sedan", "red", 2023)).to.throws(
        "Invalid Year!"
      );
    });
  });

  describe("Test brandName method", () => {
    it("should return correct result when data is correct", () => {
      expect(
        chooseYourCar.brandName(["BMW", "Toyota", "Peugeot", "Audi", "VW"], 2)
      ).to.equals("BMW, Toyota, Audi, VW");
    });

    it("should throw an exeption when brands input is not an array", () => {
      expect(() =>
        chooseYourCar.brandName("BMW Toyota Peugeot Audi VW", 2)
      ).to.throws("Invalid Information!");
    });

    it("should throw an exeption when brandIndex input is not a number", () => {
      expect(() =>
        chooseYourCar.brandName(["BMW", "Toyota", "Peugeot", "Audi", "VW"], "2")
      ).to.throws("Invalid Information!");
    });

    it("should throw an exeption when brandIndex input is below 0", () => {
      expect(() =>
        chooseYourCar.brandName(["BMW", "Toyota", "Peugeot", "Audi", "VW"], -1)
      ).to.throws("Invalid Information!");
    });

    it("should throw an exeption when brandIndex input equals the brands length", () => {
      expect(() =>
        chooseYourCar.brandName(["BMW", "Toyota", "Peugeot", "Audi", "VW"], 5)
      ).to.throws("Invalid Information!");
    });

    it("should throw an exeption when brandIndex input is bigger than the brands length", () => {
      expect(() =>
        chooseYourCar.brandName(["BMW", "Toyota", "Peugeot", "Audi", "VW"], 6)
      ).to.throws("Invalid Information!");
    });
  });

  describe("Test carFuelConsumption method", () => {
    it("should return correct message when liters per hundred km is less that 7", () => {
      expect(chooseYourCar.carFuelConsumption(100, 6)).to.equals(
        "The car is efficient enough, it burns 6.00 liters/100 km."
      );
    });

    it("should return correct message when liters per hundred km equals 7", () => {
      expect(chooseYourCar.carFuelConsumption(100, 7)).to.equals(
        "The car is efficient enough, it burns 7.00 liters/100 km."
      );
    });

    it("should return correct message when liters per hundred km equals 7", () => {
      expect(chooseYourCar.carFuelConsumption(100, 8)).to.equals(
        "The car burns too much fuel - 8.00 liters!"
      );
    });

    it("should throw an exeption when distanceInKilometers input is not a number", () => {
      expect(() => chooseYourCar.carFuelConsumption("100", 8)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when distanceInKilometers input equals 0", () => {
      expect(() => chooseYourCar.carFuelConsumption(0, 8)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when distanceInKilometers input is below 0", () => {
      expect(() => chooseYourCar.carFuelConsumption(-1, 8)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when consumptedFuelInLiters input is not a number", () => {
      expect(() => chooseYourCar.carFuelConsumption(100, "8")).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when consumptedFuelInLiters input equals 0", () => {
      expect(() => chooseYourCar.carFuelConsumption(200, 0)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when consumptedFuelInLiters input is below 0", () => {
      expect(() => chooseYourCar.carFuelConsumption(200, -1)).to.throws(
        "Invalid Information!"
      );
    });
  });
});
