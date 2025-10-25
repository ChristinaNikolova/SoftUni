let weddingDay = require("./wedding-day");
const expect = require("chai").expect;

describe("Test weddingDay object", () => {
  describe("Test weddingDay object", () => {
    it("should have correct keys", () => {
      expect(weddingDay).to.have.keys([
        "pickVenue",
        "otherSpendings",
        "tableDistribution",
      ]);
    });
  });

  describe("Test pickVenue method", () => {
    it("should return correct message when requirements are met", () => {
      expect(weddingDay.pickVenue(151, 119, "Varna")).to.equals(
        "This venue meets the requirements, with capacity of 151 guests and 119$ cover."
      );
      expect(weddingDay.pickVenue(150, 119, "Varna")).to.equals(
        "This venue meets the requirements, with capacity of 150 guests and 119$ cover."
      );
      expect(weddingDay.pickVenue(151, 120, "Varna")).to.equals(
        "This venue meets the requirements, with capacity of 151 guests and 120$ cover."
      );
      expect(weddingDay.pickVenue(150, 120, "Varna")).to.equals(
        "This venue meets the requirements, with capacity of 150 guests and 120$ cover."
      );
    });

    it("should return correct message when requirements are not met", () => {
      expect(weddingDay.pickVenue(149, 120, "Varna")).to.equals(
        "This venue does not meet your requirements!"
      );
      expect(weddingDay.pickVenue(150, 121, "Varna")).to.equals(
        "This venue does not meet your requirements!"
      );
    });

    it("should throw an exeption when location is not Varna", () => {
      expect(() => weddingDay.pickVenue(150, 120, "Burgas")).to.throws(
        "The location of this venue is not in the correct area!"
      );
    });

    it("should throw an exeption when capacity input is not a number", () => {
      expect(() => weddingDay.pickVenue("150", 120, "Varna")).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when pricePerGuest input is not a number", () => {
      expect(() => weddingDay.pickVenue(150, "120", "Varna")).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when location input is not a string", () => {
      expect(() => weddingDay.pickVenue(150, 120, ["Varna"])).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when location input is empty string", () => {
      expect(() => weddingDay.pickVenue(150, 120, "")).to.throws(
        "Invalid Information!"
      );
    });
  });

  describe("Test otherSpendings method", () => {
    it("should return correct price when input is correct and there is not discount", () => {
      expect(
        weddingDay.otherSpendings(
          ["flowers", "flowers", "Fabric drapes and curtains", "Dress"],
          ["pictures", "pictures", "video", "video 2"],
          false
        )
      ).to.equals("You spend 4100$ for wedding decoration and photography!");

      expect(
        weddingDay.otherSpendings(
          ["flowers", "flowers"],
          ["pictures", "pictures"],
          false
        )
      ).to.equals("You spend 2400$ for wedding decoration and photography!");

      expect(
        weddingDay.otherSpendings(
          ["Fabric drapes and curtains", "Fabric drapes and curtains"],
          ["video", "video"],
          false
        )
      ).to.equals("You spend 3400$ for wedding decoration and photography!");

      expect(
        weddingDay.otherSpendings(
          ["dress", "dress"],
          ["video 2", "video 2"],
          false
        )
      ).to.equals("You spend 0$ for wedding decoration and photography!");
    });

    it("should return correct price when input is correct and there is  discount", () => {
      expect(
        weddingDay.otherSpendings(
          ["flowers", "flowers", "Fabric drapes and curtains", "Dress"],
          ["pictures", "pictures", "video", "video 2"],
          true
        )
      ).to.equals(
        "You spend 3485$ for wedding decoration and photography with 15% discount!"
      );

      expect(
        weddingDay.otherSpendings(
          ["flowers", "flowers"],
          ["pictures", "pictures"],
          true
        )
      ).to.equals(
        "You spend 2040$ for wedding decoration and photography with 15% discount!"
      );

      expect(
        weddingDay.otherSpendings(
          ["Fabric drapes and curtains", "Fabric drapes and curtains"],
          ["video", "video"],
          true
        )
      ).to.equals(
        "You spend 2890$ for wedding decoration and photography with 15% discount!"
      );

      expect(
        weddingDay.otherSpendings(
          ["dress", "dress"],
          ["video 2", "video 2"],
          true
        )
      ).to.equals(
        "You spend 0$ for wedding decoration and photography with 15% discount!"
      );
    });

    it("should throw an exeption when weddingDecoration input is not an array", () => {
      expect(() =>
        weddingDay.otherSpendings(
          "flowers, flowers, Fabric drapes and curtains",
          ["pictures", "pictures", "video"],
          true
        )
      ).to.throws("Invalid Information!");
    });

    it("should throw an exeption when photography input is not an array", () => {
      expect(() =>
        weddingDay.otherSpendings(
          ["flowers", "flowers", "Fabric drapes and curtains"],
          "pictures, pictures, video",
          true
        )
      ).to.throws("Invalid Information!");
    });

    it("should throw an exeption when discount input is not a boolean", () => {
      expect(() =>
        weddingDay.otherSpendings(
          ["flowers", "flowers", "Fabric drapes and curtains"],
          ["pictures", "pictures", "video"],
          "true"
        )
      ).to.throws("Invalid Information!");
    });
  });

  describe("Test tableDistribution method", () => {
    it("should return correct message when people on table is below 6", () => {
      expect(weddingDay.tableDistribution(25, 5)).to.equals(
        "There is only 5 people on every table, you can join some tables."
      );
    });

    it("should return correct message when people on table equals 6", () => {
      expect(weddingDay.tableDistribution(24, 4)).to.equals(
        "You have 4 tables with 6 guests on table."
      );
    });

    it("should return correct message when people on table is above 6", () => {
      expect(weddingDay.tableDistribution(32, 4)).to.equals(
        "You have 4 tables with 8 guests on table."
      );
    });

    it("should throw an exeption when guests input is not a number", () => {
      expect(() => weddingDay.tableDistribution("32", 4)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when guests input is below 0", () => {
      expect(() => weddingDay.tableDistribution(-1, 4)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when guests input equals 0", () => {
      expect(() => weddingDay.tableDistribution(0, 4)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when tables input is not a number", () => {
      expect(() => weddingDay.tableDistribution(32, "4")).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when tables input is below 0", () => {
      expect(() => weddingDay.tableDistribution(32, -1)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when tables input equals 0", () => {
      expect(() => weddingDay.tableDistribution(32, 0)).to.throws(
        "Invalid Information!"
      );
    });
  });
});
