let bookSelection = require("./book-selection");
const expect = require("chai").expect;

describe("Test bookSelection object", () => {
  describe("Test bookSelection object", () => {
    it("should have correct keys", () => {
      expect(bookSelection).to.have.keys([
        "isGenreSuitable",
        "isItAffordable",
        "suitableTitles",
      ]);
    });
  });

  describe("Test isGenreSuitable method", () => {
    it("should return correct message when genre is suitable", () => {
      expect(bookSelection.isGenreSuitable("Test", 11)).to.equals(
        "Those books are suitable"
      );
      expect(bookSelection.isGenreSuitable("Test", 12)).to.equals(
        "Those books are suitable"
      );
      expect(bookSelection.isGenreSuitable("Thriller", 13)).to.equals(
        "Those books are suitable"
      );
      expect(bookSelection.isGenreSuitable("Horror", 13)).to.equals(
        "Those books are suitable"
      );
    });

    it("should return correct message when genre is not suitable", () => {
      expect(bookSelection.isGenreSuitable("Thriller", 11)).to.equals(
        "Books with Thriller genre are not suitable for kids at 11 age"
      );
      expect(bookSelection.isGenreSuitable("Horror", 11)).to.equals(
        "Books with Horror genre are not suitable for kids at 11 age"
      );
      expect(bookSelection.isGenreSuitable("Thriller", 12)).to.equals(
        "Books with Thriller genre are not suitable for kids at 12 age"
      );
      expect(bookSelection.isGenreSuitable("Horror", 12)).to.equals(
        "Books with Horror genre are not suitable for kids at 12 age"
      );
    });
  });

  describe("Test isItAffordable method", () => {
    it("should return correct message when budget is not enought", () => {
      expect(bookSelection.isItAffordable(10, 9)).to.equals(
        "You don't have enough money"
      );
    });

    it("should return correct message when budget is equal to the price", () => {
      expect(bookSelection.isItAffordable(10, 10)).to.equals(
        "Book bought. You have 0$ left"
      );
    });

    it("should return correct message when budget is enought", () => {
      expect(bookSelection.isItAffordable(10, 11)).to.equals(
        "Book bought. You have 1$ left"
      );
    });

    it("should throw an exeption when price input is not a number", () => {
      expect(() => bookSelection.isItAffordable("10", 11)).to.throws(
        "Invalid input"
      );
    });

    it("should throw an exeption when budget input is not a number", () => {
      expect(() => bookSelection.isItAffordable(10, "11")).to.throws(
        "Invalid input"
      );
    });
  });

  describe("Test suitableTitles method", () => {
    const array = [
      { title: "The Da Vinci Code", genre: "Thriller" },
      { title: "Gone Girl", genre: "Thriller" },
      { title: "To Kill a Mockingbird", genre: "Fiction" },
      { title: "1984", genre: "Dystopian" },
      { title: "The Hobbit", genre: "Fantasy" },
    ];

    it("should return correct books", () => {
      expect(bookSelection.suitableTitles(array, "Thriller")).to.deep.equals([
        "The Da Vinci Code",
        "Gone Girl",
      ]);
      expect(bookSelection.suitableTitles(array, "Fiction")).to.deep.equals([
        "To Kill a Mockingbird",
      ]);
      expect(bookSelection.suitableTitles(array, "Test")).to.deep.equals([]);
    });

    it("should throw an exeption when array input is not an array", () => {
      expect(() =>
        bookSelection.suitableTitles("The Da Vinci Code: Thriller", "Thriller")
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when wantedGenre input is not an string", () => {
      expect(() => bookSelection.suitableTitles(array, ["Thriller"])).to.throws(
        "Invalid input"
      );
    });
  });
});
