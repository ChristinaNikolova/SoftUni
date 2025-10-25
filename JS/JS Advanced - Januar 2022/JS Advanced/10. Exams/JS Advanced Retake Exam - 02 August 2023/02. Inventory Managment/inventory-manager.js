class InventoryManager {
  constructor(capacity) {
    this.capacity = capacity;
    this.items = [];
    this.outOfStock = [];
  }

  addItem(itemName, quantity) {
    this.checkQuantity(quantity);

    if (this.capacity === this.items.length) {
      throw new Error("The inventory is already full.");
    }

    this.updateItems(itemName, quantity);

    return `Added ${quantity} ${itemName}(s) to the inventory.`;
  }

  sellItem(itemName, quantity) {
    this.checkQuantity(quantity);

    const targetItem = this.items.find((x) => x.itemName === itemName);

    if (!targetItem) {
      throw new Error(
        `The item ${itemName} is not available in the inventory.`
      );
    }

    if (targetItem.quantity < quantity) {
      throw new Error(`Not enough ${itemName}(s) in stock.`);
    }

    targetItem.quantity -= quantity;

    if (targetItem.quantity === 0) {
      this.items = this.items.filter((x) => x.itemName !== itemName);
      this.outOfStock.push(targetItem.itemName);
    }

    return `Sold ${quantity} ${itemName}(s) from the inventory.`;
  }

  restockItem(itemName, quantity) {
    this.checkQuantity(quantity);
    this.updateItems(itemName, quantity);
    this.outOfStock = this.outOfStock.filter((x) => x !== itemName);

    return `Restocked ${quantity} ${itemName}(s) in the inventory.`;
  }

  getInventorySummary() {
    const result = ["Current Inventory:"];
    result.push(...this.items.map((x) => `${x.itemName}: ${x.quantity}`));

    if (this.outOfStock.length) {
      result.push(`Out of Stock: ${this.outOfStock.join(", ")}`);
    }

    return result.join("\n");
  }

  updateItems(itemName, quantity) {
    const targetItem = this.items.find((x) => x.itemName === itemName);

    if (!targetItem) {
      this.items.push({ itemName, quantity });
    } else {
      targetItem.quantity += quantity;
    }
  }

  checkQuantity(quantity) {
    if (quantity <= 0) {
      throw new Error("Quantity must be greater than zero.");
    }
  }
}

// const manager = new InventoryManager(2);
// console.log(manager.addItem("Drill", 10));
// console.log(manager.addItem("Hammer", 5));
// console.log(manager.addItem("Level", 3));

// const manager = new InventoryManager(3);
// console.log(manager.addItem("Drill", 10));
// console.log(manager.addItem("Hammer", 5));
// console.log(manager.addItem("Chisel", 3));
// console.log(manager.sellItem("Drill", 3));
// console.log(manager.sellItem("Paintbrush", 2));

// const manager = new InventoryManager(3);
// console.log(manager.addItem("Drill", 10));
// console.log(manager.addItem("Hammer", 5));
// console.log(manager.addItem("Chisel", 3));
// console.log(manager.sellItem("Drill", 3));
// console.log(manager.restockItem("Drill", 5));
// console.log(manager.restockItem("Paintbrush", 1));

const manager = new InventoryManager(3);
console.log(manager.addItem("Drill", 10));
console.log(manager.addItem("Hammer", 5));
console.log(manager.addItem("Chisel", 3));
console.log(manager.sellItem("Drill", 3));
console.log(manager.sellItem("Hammer", 5));
console.log(manager.restockItem("Drill", 5));
console.log(manager.restockItem("Paintbrush", 1));
console.log(manager.getInventorySummary());
