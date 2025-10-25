let artGallery = require("./art-gallery");
const expect = require("chai").expect;

describe("Test artGallery object", () => {
  describe("Test artGallery object", () => {
    it("should have correct keys", () => {
      expect(artGallery).to.have.keys([
        "addArtwork",
        "calculateCosts",
        "organizeExhibits",
      ]);
    });
  });

  describe("Test addArtwork method", () => {
    it("should return correct message when input data is correct", () => {
      expect(
        artGallery.addArtwork("Test Title", "20 x 30", "Picasso")
      ).to.equals(
        "Artwork added successfully: 'Test Title' by Picasso with dimensions 20 x 30."
      );
    });

    it("should throw an expection when input title is not a string", () => {
      expect(() =>
        artGallery.addArtwork(["Test Title"], "20 x 30", "Picasso")
      ).to.throws("Invalid Information!");
    });

    it("should throw an expection when input artist is not a string", () => {
      expect(() =>
        artGallery.addArtwork("Test Title", "20 x 30", ["Picasso"])
      ).to.throws("Invalid Information!");
    });

    it("should throw an expection when input dimensions does not match the pattern", () => {
      expect(() =>
        artGallery.addArtwork("Test Title", "20x 30", "Picasso")
      ).to.throws("Invalid Dimensions!");
    });

    it("should throw an expection when input artist is not present in the gallery", () => {
      expect(() =>
        artGallery.addArtwork("Test Title", "20 x 30", "Pesho")
      ).to.throws("This artist is not allowed in the gallery!");
    });
  });

  describe("Test calculateCosts method", () => {
    it("should calculate total price correctly when there is a sponsor", () => {
      expect(artGallery.calculateCosts(12000, 15000, true)).to.equals(
        "Exhibition and insurance costs are 24300$, reduced by 10% with the help of a donation from your sponsor."
      );
    });

    it("should calculate total price correctly when there isn't a sponsor", () => {
      expect(artGallery.calculateCosts(12000, 15000, false)).to.equals(
        "Exhibition and insurance costs are 27000$."
      );
    });

    it("should throw an exeption when exhibitionCosts input is not a number", () => {
      expect(() => artGallery.calculateCosts("12000", 15000, false)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when insuranceCosts input is not a number", () => {
      expect(() => artGallery.calculateCosts(12000, "15000", false)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when sponsor input is not a boolean", () => {
      expect(() => artGallery.calculateCosts(12000, 15000, "false")).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when exhibitionCosts input is below 0", () => {
      expect(() => artGallery.calculateCosts(-1, 15000, false)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when insuranceCosts input is below 0", () => {
      expect(() => artGallery.calculateCosts(12000, -1, false)).to.throws(
        "Invalid Information!"
      );
    });
  });

  describe("Test organizeExhibits method", () => {
    it("should return correct message when artworks per space is below 5", () => {
      expect(artGallery.organizeExhibits(8, 4)).to.equals(
        "There are only 2 artworks in each display space, you can add more artworks."
      );
    });

    it("should return correct message when artworks per space equals 5", () => {
      expect(artGallery.organizeExhibits(10, 2)).to.equals(
        "You have 2 display spaces with 5 artworks in each space."
      );
    });

    it("should return correct message when artworks per space is above 5", () => {
      expect(artGallery.organizeExhibits(12, 2)).to.equals(
        "You have 2 display spaces with 6 artworks in each space."
      );
    });

    it("should throw an exeption when artworksCount input is not a number", () => {
      expect(() => artGallery.organizeExhibits("12", 2)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when displaySpacesCount input is not a number", () => {
      expect(() => artGallery.organizeExhibits(12, "2")).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when artworksCount equals 0", () => {
      expect(() => artGallery.organizeExhibits(0, 2)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when artworksCount is below 0", () => {
      expect(() => artGallery.organizeExhibits(-1, 2)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when displaySpacesCount equals 0", () => {
      expect(() => artGallery.organizeExhibits(12, 0)).to.throws(
        "Invalid Information!"
      );
    });

    it("should throw an exeption when displaySpacesCount is below 0", () => {
      expect(() => artGallery.organizeExhibits(12, -1)).to.throws(
        "Invalid Information!"
      );
    });
  });
});
