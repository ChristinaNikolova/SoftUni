class RefurbishedSmartphones {
  constructor(retailer) {
    this.retailer = retailer;
    this.availableSmartphones = [];
    this.soldSmartphones = [];
    this.revenue = 0;
  }

  addSmartphone(model, storage, price, condition) {
    if (
      !model ||
      !storage ||
      !price ||
      !condition ||
      !Number.isInteger(storage) ||
      storage < 0 ||
      price < 0
    ) {
      throw new Error("Invalid smartphone!");
    }

    this.availableSmartphones.push({ model, storage, condition, price });

    return `New smartphone added: ${model} / ${storage} GB / ${condition} condition - ${price.toFixed(
      2
    )}$`;
  }

  sellSmartphone(model, desiredStorage) {
    const targetSmartPhone = this.availableSmartphones.find(
      (x) => x.model === model
    );

    if (!targetSmartPhone) {
      throw new Error(`${model} was not found!`);
    }

    let soldPrice = targetSmartPhone.price;

    if (desiredStorage <= targetSmartPhone.storage) {
      soldPrice = targetSmartPhone.price;
    } else if (desiredStorage - targetSmartPhone.storage <= 128) {
      soldPrice -= 0.1 * targetSmartPhone.price;
    } else {
      soldPrice -= 0.2 * targetSmartPhone.price;
    }

    this.availableSmartphones = this.availableSmartphones.filter(
      (x) => x.model !== model
    );
    this.soldSmartphones.push({
      model,
      storage: targetSmartPhone.storage,
      soldPrice,
    });
    this.revenue += soldPrice;

    return `${model} was sold for ${soldPrice.toFixed(2)}$`;
  }

  upgradePhones() {
    if (!this.availableSmartphones.length) {
      throw new Error("There are no available smartphones!");
    }

    for (const curr of this.availableSmartphones) {
      curr.storage *= 2;
    }

    const result = this.availableSmartphones
      .map(
        (x) =>
          `${x.model} / ${x.storage} GB / ${
            x.condition
          } condition / ${x.price.toFixed(2)}$`
      )
      .join("\n");

    return `Upgraded Smartphones:\n${result}`;
  }

  salesJournal(criteria) {
    if (criteria !== "storage" && criteria !== "model") {
      throw new Error("Invalid criteria!");
    }

    if (criteria === "storage") {
      this.soldSmartphones.sort((a, b) => b.storage - a.storage);
    } else {
      this.soldSmartphones.sort((a, b) => a.model.localeCompare(b.model));
    }

    let result = this.soldSmartphones
      .map((x) => `${x.model} / ${x.storage} GB / ${x.soldPrice.toFixed(2)}$`)
      .join("\n");

    return `${this.retailer} has a total income of ${this.revenue.toFixed(
      2
    )}$\n${this.soldSmartphones.length} smartphones sold:\n${result}`;
  }
}

// let retailer = new RefurbishedSmartphones("SecondLife Devices");
// console.log(retailer.addSmartphone("Samsung S20 Ultra", 256, 1000, "good"));
// console.log(retailer.addSmartphone("Iphone 12 mini", 128, 800, "perfect"));
// console.log(retailer.addSmartphone("", 512, 1900, "good"));

// let retailer = new RefurbishedSmartphones("SecondLife Devices");
// retailer.addSmartphone("Samsung S20 Ultra", 256, 1000, "good");
// retailer.addSmartphone("Iphone 12 mini", 128, 800, "perfect");
// retailer.addSmartphone("Xiaomi Redmi Note 10 Pro", 128, 330, "perfect");
// console.log(retailer.sellSmartphone("Samsung S20 Ultra", 256));
// console.log(retailer.sellSmartphone("Xiaomi Redmi Note 10 Pro", 256));
// console.log(retailer.sellSmartphone("Samsung Galaxy A13", 64));

// let retailer = new RefurbishedSmartphones("SecondLife Devices");
// retailer.addSmartphone("Samsung S20 Ultra", 256, 1000, "good");
// retailer.addSmartphone("Iphone 12 mini", 128, 800, "perfect");
// retailer.addSmartphone("Xiaomi Redmi Note 10 Pro", 128, 330, "perfect");
// console.log(retailer.upgradePhones());

let retailer = new RefurbishedSmartphones("SecondLife Devices");
retailer.addSmartphone("Samsung S20 Ultra", 256, 1000, "good");
retailer.addSmartphone("Iphone 12 mini", 128, 800, "perfect");
retailer.addSmartphone("Xiaomi Redmi Note 10 Pro", 128, 330, "perfect");
retailer.sellSmartphone("Samsung S20 Ultra", 256);
retailer.sellSmartphone("Xiaomi Redmi Note 10 Pro", 256);
console.log(retailer.salesJournal("model"));
