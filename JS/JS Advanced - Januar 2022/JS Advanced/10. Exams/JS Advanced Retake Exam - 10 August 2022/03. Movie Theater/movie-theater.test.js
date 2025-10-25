let movieTheater = require("./movie-theater");
const expect = require("chai").expect;

describe("Test movieTheater object", () => {
  describe("Test movieTheater object", () => {
    it("should have correct keys", () => {
      expect(movieTheater).to.have.keys([
        "ageRestrictions",
        "moneySpent",
        "reservation",
      ]);
    });
  });

  describe("Test ageRestrictions method", () => {
    it("should return correct message", () => {
      expect(movieTheater.ageRestrictions("G")).to.equals(
        "All ages admitted to watch the movie"
      );
      expect(movieTheater.ageRestrictions("PG")).to.equals(
        "Parental guidance suggested! Some material may not be suitable for pre-teenagers"
      );
      expect(movieTheater.ageRestrictions("R")).to.equals(
        "Restricted! Under 17 requires accompanying parent or adult guardian"
      );
      expect(movieTheater.ageRestrictions("NC-17")).to.equals(
        "No one under 17 admitted to watch the movie"
      );
      expect(movieTheater.ageRestrictions("Test")).to.equals(
        "There are no age restrictions for this movie"
      );
      expect(movieTheater.ageRestrictions()).to.equals(
        "There are no age restrictions for this movie"
      );
    });
  });

  describe("Test moneySpent method", () => {
    it("should return correct message when bill is above 50", () => {
      expect(
        movieTheater.moneySpent(
          2,
          ["Nachos", "Nachos", "Popcorn", "Popcorn"],
          ["Soda", "Soda", "Water"]
        )
      ).to.equals(
        "The total cost for the purchase with applied discount is 46.00"
      );
    });

    it("should return correct message when bill is equal to 50", () => {
      expect(movieTheater.moneySpent(3, [], ["Soda", "Soda"])).to.equals(
        "The total cost for the purchase is 50.00"
      );
    });

    it("should return correct message when bill is below 50", () => {
      expect(movieTheater.moneySpent(3, [], ["Soda", "Water"])).to.equals(
        "The total cost for the purchase is 49.00"
      );
    });

    it("should throw an exeption when tickets input is not a number", () => {
      expect(() =>
        movieTheater.moneySpent("3", ["Nachos", "Nachos"], ["Soda", "Water"])
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when food input is not an array", () => {
      expect(() =>
        movieTheater.moneySpent(3, "Nachos, Nachos", ["Soda", "Water"])
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when drinks input is not an array", () => {
      expect(() =>
        movieTheater.moneySpent(3, ["Nachos", "Nachos"], "Soda Water")
      ).to.throws("Invalid input");
    });
  });

  describe("Test reservation method", () => {
    it("should return correct result when data is valid", () => {
      expect(
        movieTheater.reservation(
          [
            { rowNumber: 1, freeSeats: 7 },
            { rowNumber: 2, freeSeats: 5 },
          ],
          5
        )
      ).to.equals(2);
    });

    it("should throw an exeption when rowsArray input is not an array", () => {
      expect(() =>
        movieTheater.reservation({ rowNumber: 1, freeSeats: 7 }, 5)
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when neededSeatsCount input is not a number", () => {
      expect(() =>
        movieTheater.reservation(
          [
            { rowNumber: 1, freeSeats: 7 },
            { rowNumber: 2, freeSeats: 5 },
          ],
          "5"
        )
      ).to.throws("Invalid input");
    });
  });
});
