class FashionRetailInventory {
  constructor(storehouse, location) {
    this.storeHouse = storehouse;
    this.location = location;
    this.productStock = [];
  }

  addProduct(productName, size, quantity, price) {
    const targetProduct = this.productStock.find(
      (x) => x.productName === productName && x.size === size
    );

    if (targetProduct) {
      targetProduct.quantity += quantity;
      return `You added ${quantity} more pieces of product ${productName} size ${size}`;
    }

    this.productStock.push({
      productName,
      size,
      quantity,
      price,
    });

    return `The product ${productName}, size ${size} was successfully added to the inventory`;
  }

  sendProduct(productName, size) {
    const targetProductIndex = this.productStock.findIndex(
      (x) => x.productName === productName && x.size === size
    );

    if (targetProductIndex === -1) {
      throw new Error(
        `The product ${productName}, size ${size} is not in the inventory`
      );
    }

    this.productStock.splice(targetProductIndex, 1);

    return `The product ${productName}, size ${size} was successfully removed from the inventory`;
  }

  findProductsBySize(size) {
    const targetProducts = this.productStock.filter((x) => x.size === size);

    if (!targetProducts.length) {
      return "There are no products available in that size";
    }

    return targetProducts
      .map((x) => `${x.productName}-${x.quantity} pieces`)
      .join(", ");
  }

  listProducts() {
    if (!this.productStock.length) {
      return `${this.storeHouse} storehouse is empty`;
    }

    const sortedProducts = this.productStock
      .sort((a, b) => a.productName.localeCompare(b.productName))
      .map(
        (x) =>
          `${x.productName}/Size:${x.size}/Quantity:${x.quantity}/Price:${x.price}$`
      )
      .join("\n");

    return `${this.storeHouse} storehouse in ${this.location} available products:\n${sortedProducts}`;
  }
}

// const store = new FashionRetailInventory("East", "Milano");
// console.log(store.addProduct("Shirt", "M", 10, 25.0));
// console.log(store.addProduct("T-Shirt", "M", 10, 25.0));
// console.log(store.addProduct("Sweather", "M", 10, 25.0));
// console.log(store.addProduct("Sweather", "M", 10, 25.0));

// const store = new FashionRetailInventory("East", "Milano");
// console.log(store.addProduct("Shirt", "M", 10, 25.0));
// console.log(store.addProduct("T-Shirt", "M", 10, 25.0));
// console.log(store.sendProduct("T-Shirt", "M"));
// console.log(store.sendProduct("Sweather", "M"));

// const store = new FashionRetailInventory("East", "Milano");
// console.log(store.addProduct("Shirt", "M", 10, 25.0));
// console.log(store.addProduct("T-Shirt", "M", 10, 25.0));
// console.log(store.findProductsBySize("M"));
// console.log(store.findProductsBySize("XL"));

const store = new FashionRetailInventory("East", "Milano");
console.log(store.addProduct("Shirt", "M", 10, 25.0));
console.log(store.addProduct("T-Shirt", "M", 10, 25.0));
console.log(store.addProduct("Shirt", "L", 5, 30.0));
console.log(store.addProduct("Shoes", "9", 8, 50.0));
console.log(store.sendProduct("Shoes", "9", 8, 50.0));
console.log(store.listProducts());
