let streamingServiceSelector = require("./streaming-service-selector");
const expect = require("chai").expect;

describe("Test streamingServiceSelector object", () => {
  describe("Test streamingServiceSelector object", () => {
    it("should have correct keys", () => {
      expect(streamingServiceSelector).to.have.keys([
        "selectingContent",
        "availablePlatforms",
        "contentRating",
      ]);
    });
  });

  describe("Test selectingContent method", () => {
    it("should return correct message when input data is correct", () => {
      expect(
        streamingServiceSelector.selectingContent(
          "Movie",
          "Test Platform",
          "Romance"
        )
      ).to.equals(
        "You can watch this Romance Movie on Test Platform. Enjoy your Romance-filled experience!"
      );
      expect(
        streamingServiceSelector.selectingContent(
          "TV Show",
          "Test Platform",
          "Romance"
        )
      ).to.equals(
        "You can watch this Romance TV Show on Test Platform. Enjoy your Romance-filled experience!"
      );
    });

    it("should throw an expection when type does not exist", () => {
      expect(() =>
        streamingServiceSelector.selectingContent(
          "test",
          "Test Platform",
          "Romance"
        )
      ).to.throws("We currently only support 'Movie' or 'TV Show' types.");
    });

    it("should throw an expection when genre does not exist", () => {
      expect(() =>
        streamingServiceSelector.selectingContent(
          "Movie",
          "Test Platform",
          "Test"
        )
      ).to.throws(
        "We currently support these genres: Action, Comedy, Drama, Thriller, Horror, Romance, Sci-Fi."
      );
    });
  });

  describe("Test availablePlatforms method", () => {
    it("should return correct message when input data is correct", () => {
      expect(
        streamingServiceSelector.availablePlatforms(
          ["Test 1", "Test 2", "Test 3"],
          1
        )
      ).to.equals("Other available platforms are: Test 1, Test 3.");
    });

    it("should throw an expection when platforms input is not an array", () => {
      expect(() =>
        streamingServiceSelector.availablePlatforms("Test 1, Test 2, Test 3", 1)
      ).to.throws("Invalid platform selection.");
    });

    it("should throw an expection when selectedPlatformIndex input is not an integer", () => {
      expect(() =>
        streamingServiceSelector.availablePlatforms(
          ["Test 1", "Test 2", "Test 3"],
          1.1
        )
      ).to.throws("Invalid platform selection.");
    });

    it("should throw an expection when selectedPlatformIndex is below 0", () => {
      expect(() =>
        streamingServiceSelector.availablePlatforms(
          ["Test 1", "Test 2", "Test 3"],
          -1
        )
      ).to.throws("Invalid platform selection.");
    });

    it("should throw an expection when selectedPlatformIndex is equal to the platforms length", () => {
      expect(() =>
        streamingServiceSelector.availablePlatforms(
          ["Test 1", "Test 2", "Test 3"],
          3
        )
      ).to.throws("Invalid platform selection.");
    });

    it("should throw an expection when selectedPlatformIndex is greater that platforms length", () => {
      expect(() =>
        streamingServiceSelector.availablePlatforms(
          ["Test 1", "Test 2", "Test 3"],
          4
        )
      ).to.throws("Invalid platform selection.");
    });
  });

  describe("Test contentRating method", () => {
    it("should return correct message when viewerRating is lower that 7", () => {
      expect(streamingServiceSelector.contentRating(120, 6)).to.equals(
        "This content has a lower rating (6/10) and runs for 2.00 hours. You might want to check reviews first."
      );
    });

    it("should return correct message when viewerRating is equal to 7", () => {
      expect(streamingServiceSelector.contentRating(120, 7)).to.equals(
        "This content is highly rated (7/10) and has a runtime of 2.00 hours. Enjoy your watch!"
      );
    });

    it("should return correct message when viewerRating is greater that 7", () => {
      expect(streamingServiceSelector.contentRating(120, 8)).to.equals(
        "This content is highly rated (8/10) and has a runtime of 2.00 hours. Enjoy your watch!"
      );
    });

    it("should throw an expection when runtimeInMinutes input is not a number", () => {
      expect(() => streamingServiceSelector.contentRating("120", 8)).to.throws(
        "Invalid runtime or rating."
      );
    });

    it("should throw an expection when runtimeInMinutes input is below 0", () => {
      expect(() => streamingServiceSelector.contentRating(-1, 8)).to.throws(
        "Invalid runtime or rating."
      );
    });

    it("should throw an expection when runtimeInMinutes input is equal to 0", () => {
      expect(() => streamingServiceSelector.contentRating(0, 8)).to.throws(
        "Invalid runtime or rating."
      );
    });

    it("should throw an expection when viewerRating input is not a number", () => {
      expect(() => streamingServiceSelector.contentRating(120, "8")).to.throws(
        "Invalid runtime or rating."
      );
    });

    it("should throw an expection when viewerRating input is below 0", () => {
      expect(() => streamingServiceSelector.contentRating(120, -1)).to.throws(
        "Invalid runtime or rating."
      );
    });

    it("should throw an expection when viewerRating input is above 10", () => {
      expect(() => streamingServiceSelector.contentRating(120, 11)).to.throws(
        "Invalid runtime or rating."
      );
    });
  });
});
