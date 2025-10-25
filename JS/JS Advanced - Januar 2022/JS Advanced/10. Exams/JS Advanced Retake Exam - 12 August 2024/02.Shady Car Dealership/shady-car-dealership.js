class ShadyCarDealership {
  constructor(dealerName) {
    this.dealerName = dealerName;
    this.availableCars = [];
    this.soldCars = [];
    this.revenue = 0;
  }

  addCar(model, year, mileage, price) {
    if (
      !model ||
      !year ||
      !mileage ||
      !price ||
      Number(year) < 1950 ||
      Number(mileage) < 0 ||
      Number(price) < 0
    ) {
      throw new Error("Invalid car!");
    }

    this.availableCars.push({
      model,
      year,
      mileage,
      price,
    });

    return `New car added: ${model} (${year}) / ${mileage} km. - ${price.toFixed(
      2
    )}$`;
  }

  sellCar(model, desiredYear) {
    const targetCar = this.availableCars.find((x) => x.model === model);

    if (!targetCar) {
      return `${model} was not found!`;
    }

    let soldPrice = targetCar.price;

    if (targetCar.year >= desiredYear) {
      soldPrice = targetCar.price;
    } else if (desiredYear - targetCar.year <= 5) {
      soldPrice -= 0.1 * soldPrice;
    } else if (desiredYear - targetCar.year > 5) {
      soldPrice -= 0.2 * soldPrice;
    }

    this.availableCars = this.availableCars.filter(
      (x) => x.model !== targetCar.model
    );

    this.soldCars.push({
      model: targetCar.model,
      year: targetCar.year,
      mileage: targetCar.mileage,
      soldPrice,
    });
    this.revenue += soldPrice;

    return `${model} (${targetCar.year}) was sold for ${soldPrice.toFixed(2)}$`;
  }

  prepareCarForSale(model) {
    const targetCar = this.availableCars.find((x) => x.model === model);
    if (!targetCar) {
      return `${model} was not found for preparation!`;
    }

    targetCar.mileage -= 0.5 * targetCar.mileage;
    targetCar.price += 0.3 * targetCar.price;

    return `${model} (${targetCar.year}) is prepared for sale with ${
      targetCar.mileage
    } km. - ${targetCar.price.toFixed(2)}$`;
  }

  salesJournal(criteria) {
    if (criteria !== "year" && criteria !== "model") {
      throw new Error("Invalid criteria!");
    }

    let result;

    if (criteria === "year") {
      result = this.soldCars.sort((a, b) => b.year - a.year);
    } else {
      result = this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
    }

    result = result
      .map(
        (x) =>
          `${x.model} (${x.year}) / ${x.mileage} km. / ${x.soldPrice.toFixed(
            2
          )}$`
      )
      .join("\n");

    return `${this.dealerName} has a total income of ${this.revenue.toFixed(
      2
    )}$\n${this.soldCars.length} cars sold:\n${result}`;
  }
}

// const dealership = new ShadyCarDealership("Shady Motors");
// console.log(dealership.addCar("Honda CR-V", 2010, 120000, 15000));
// console.log(dealership.addCar("VW Golf", 2011, 130000, 12000));
// console.log(dealership.addCar("BMW X3", 2005, 220000, 9000));
// console.log(dealership.addCar("Toyota Yaris", 2015, 80000, 18000));

// const dealership = new ShadyCarDealership("Shady Motors");
// console.log(dealership.addCar("Honda CR-V", 2010, 120000, 15000));
// console.log(dealership.addCar("VW Golf", 2011, 130000, 12000));
// console.log(dealership.addCar("BMW X3", 2005, 220000, 9000));
// console.log(dealership.addCar("Toyota Yaris", 2015, 80000, 18000));
// console.log(dealership.prepareCarForSale("Honda CR-V"));
// console.log(dealership.prepareCarForSale("Honda Jazz"));

const dealership = new ShadyCarDealership("Shady Motors");
console.log(dealership.addCar("Honda CR-V", 2010, 120000, 15000));
console.log(dealership.addCar("BMW X3", 2005, 220000, 9000));
console.log(dealership.addCar("Toyota Yaris", 2015, 80000, 18000));
console.log(dealership.prepareCarForSale("Honda CR-V"));
console.log(dealership.prepareCarForSale("BMW X3"));
console.log(dealership.sellCar("Honda CR-V", 2012));
console.log(dealership.sellCar("BMW X3", 2012));
console.log(dealership.sellCar("Toyota Yaris", 2012));

// const dealership = new ShadyCarDealership("Shady Motors");
// console.log(dealership.addCar("Honda CR-V", 2010, 120000, 15000));
// console.log(dealership.addCar("VW Golf", 2011, 130000, 12000));
// console.log(dealership.addCar("BMW X3", 2005, 220000, 9000));
// console.log(dealership.prepareCarForSale("Honda CR-V"));
// console.log(dealership.prepareCarForSale("BMW X3"));
// console.log(dealership.sellCar("Honda CR-V", 2012));
// console.log(dealership.sellCar("BMW X3", 2012));
// console.log(dealership.sellCar("VW Golf", 2006));
// console.log(dealership.salesJournal("model"));
