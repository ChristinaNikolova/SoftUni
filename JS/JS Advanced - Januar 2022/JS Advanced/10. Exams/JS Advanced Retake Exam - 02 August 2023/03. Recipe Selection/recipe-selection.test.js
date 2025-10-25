let recipeSelection = require("./recipe-selection");
const expect = require("chai").expect;

describe("Test recipeSelection object", () => {
  describe("Test recipeSelection object", () => {
    it("should have correct keys", () => {
      expect(recipeSelection).to.have.keys([
        "isTypeSuitable",
        "isItAffordable",
        "getRecipesByCategory",
      ]);
    });
  });

  describe("Test isTypeSuitable method", () => {
    it("should return correct message when there is no restriction", () => {
      expect(recipeSelection.isTypeSuitable("Meat", "Everything")).to.equals(
        "This recipe is suitable for your dietary restriction"
      );
      expect(recipeSelection.isTypeSuitable("Fruits", "Vegetarian")).to.equals(
        "This recipe is suitable for your dietary restriction"
      );
      expect(recipeSelection.isTypeSuitable("Fruits", "Vegan")).to.equals(
        "This recipe is suitable for your dietary restriction"
      );
    });

    it("should return correct message when type is Meat and dietaryRestriction is Vegetarian", () => {
      expect(recipeSelection.isTypeSuitable("Meat", "Vegetarian")).to.equals(
        "This recipe is not suitable for vegetarians"
      );
    });

    it("should return correct message when type is Meat and dietaryRestriction is Vegan", () => {
      expect(recipeSelection.isTypeSuitable("Meat", "Vegan")).to.equals(
        "This recipe is not suitable for vegans"
      );
    });

    it("should return correct message when type is Meat and dietaryRestriction is Dairy", () => {
      expect(recipeSelection.isTypeSuitable("Dairy", "Vegan")).to.equals(
        "This recipe is not suitable for vegans"
      );
    });

    it("should throw an exeption when input type is not a string", () => {
      expect(() =>
        recipeSelection.isTypeSuitable(["Dairy"], "Vegan")
      ).to.throws("Invalid input");
    });

    it("should throw an exeption when dietaryRestriction type is not a string", () => {
      expect(() =>
        recipeSelection.isTypeSuitable("Dairy", ["Vegan"])
      ).to.throws("Invalid input");
    });
  });

  describe("Test isItAffordable method", () => {
    it("shhould return correct message when budget is enoght", () => {
      expect(recipeSelection.isItAffordable(100, 101)).to.equals(
        "Recipe ingredients bought. You have 1$ left"
      );
    });

    it("shhould return correct message when budget is equal to the price", () => {
      expect(recipeSelection.isItAffordable(100, 100)).to.equals(
        "Recipe ingredients bought. You have 0$ left"
      );
    });

    it("shhould return correct message when budget is not enoght", () => {
      expect(recipeSelection.isItAffordable(100, 99)).to.equals(
        "You don't have enough budget to afford this recipe"
      );
    });

    it("should throw an exeption when price input is not a number", () => {
      expect(() => recipeSelection.isItAffordable("100", 99)).to.throws(
        "Invalid input"
      );
    });

    it("should throw an exeption when budget input is not a number", () => {
      expect(() => recipeSelection.isItAffordable(100, "99")).to.throws(
        "Invalid input"
      );
    });
  });

  describe("Test getRecipesByCategory method", () => {
    const recipes = [
      { title: "R1", category: "1" },
      { title: "R2", category: "1" },
      { title: "R3", category: "2" },
    ];

    it("should return correct message when input data is valid", () => {
      expect(recipeSelection.getRecipesByCategory(recipes, "1")).to.deep.equals(
        ["R1", "R2"]
      );
      expect(recipeSelection.getRecipesByCategory(recipes, "2")).to.deep.equals(
        ["R3"]
      );
      expect(recipeSelection.getRecipesByCategory(recipes, "3")).to.deep.equals(
        []
      );
    });

    it("should throw an exeption when recipes input is not an array", () => {
      expect(() => recipeSelection.getRecipesByCategory(100, "1")).to.throws(
        "Invalid input"
      );
    });

    it("should throw an exeption when category input is not a string", () => {
      expect(() => recipeSelection.getRecipesByCategory(recipes, 1)).to.throws(
        "Invalid input"
      );
    });
  });
});
