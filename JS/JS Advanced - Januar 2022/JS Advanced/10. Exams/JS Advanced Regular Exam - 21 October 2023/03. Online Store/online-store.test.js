let onlineStore = require("./online-store");
const expect = require("chai").expect;

describe("Test onlineStore object", () => {
  describe("Test onlineStore object", () => {
    it("should have correct keys", () => {
      expect(onlineStore).to.have.keys([
        "isProductAvailable",
        "canAffordProduct",
        "getRecommendedProducts",
      ]);
    });
  });

  describe("Test isProductAvailable method", () => {
    it("should return correct message when product quantity is above 0", () => {
      expect(onlineStore.isProductAvailable("test", 1)).to.equals(
        "Great! test is available for purchase."
      );
    });

    it("should return correct message when product quantity is equal to 0", () => {
      expect(onlineStore.isProductAvailable("test", 0)).to.equals(
        "Sorry, test is currently out of stock."
      );
    });

    it("should return correct message when product quantity is below 0", () => {
      expect(onlineStore.isProductAvailable("test", -1)).to.equals(
        "Sorry, test is currently out of stock."
      );
    });

    it("should throw an exeption when product input is not a string", () => {
      expect(() => onlineStore.isProductAvailable(["test"], 1)).to.throws(
        "Invalid input."
      );
    });

    it("should throw an exeption when stockQuantity input is not a number", () => {
      expect(() => onlineStore.isProductAvailable("test", "1")).to.throws(
        "Invalid input."
      );
    });
  });

  describe("Test canAffordProduct method", () => {
    it("should return correct message when balance is above 0", () => {
      expect(onlineStore.canAffordProduct(15, 16)).to.equals(
        "Product purchased. Your remaining balance is $1."
      );
    });

    it("should return correct message when balance is equal to 0", () => {
      expect(onlineStore.canAffordProduct(15, 15)).to.equals(
        "Product purchased. Your remaining balance is $0."
      );
    });

    it("should return correct message when balance is below 0", () => {
      expect(onlineStore.canAffordProduct(15, 14)).to.equals(
        "You don't have sufficient funds to buy this product."
      );
    });

    it("should throw an exeption when productPrice input is not a number", () => {
      expect(() => onlineStore.canAffordProduct("15", 14)).to.throws(
        "Invalid input."
      );
    });

    it("should throw an exeption when accountBalance input is not a number", () => {
      expect(() => onlineStore.canAffordProduct(15, "14")).to.throws(
        "Invalid input."
      );
    });
  });

  describe("Test getRecommendedProducts method", () => {
    const productList = [
      { name: "test 1", category: "category 1" },
      { name: "test 2", category: "category 1" },
      { name: "test 3", category: "category 2" },
    ];

    it("should return correct message when recommendedProducts is above 0", () => {
      expect(
        onlineStore.getRecommendedProducts(productList, "category 1")
      ).to.equals(
        "Recommended products in the category 1 category: test 1, test 2"
      );
      expect(
        onlineStore.getRecommendedProducts(productList, "category 2")
      ).to.equals("Recommended products in the category 2 category: test 3");
    });

    it("should return correct message when recommendedProducts equals 0", () => {
      expect(
        onlineStore.getRecommendedProducts(productList, "category 4")
      ).to.equals(
        "Sorry, we currently have no recommended products in the category 4 category."
      );
    });

    it("should throw an exeption when productList input is not an array", () => {
      expect(() =>
        onlineStore.getRecommendedProducts("productList", "category 4")
      ).to.throws("Invalid input.");
    });

    it("should throw an exeption when category input is not a string", () => {
      expect(() =>
        onlineStore.getRecommendedProducts(productList, ["category 4"])
      ).to.throws("Invalid input.");
    });
  });
});
