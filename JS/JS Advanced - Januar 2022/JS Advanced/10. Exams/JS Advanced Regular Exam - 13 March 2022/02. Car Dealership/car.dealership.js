class CarDealership {
  constructor(name) {
    this.name = name;
    this.availableCars = [];
    this.soldCars = [];
    this.totalIncome = 0;
  }

  addCar(model, horsepower, price, mileage) {
    if (
      !model ||
      !Number.isInteger(horsepower) ||
      horsepower < 0 ||
      price < 0 ||
      mileage < 0
    ) {
      throw new Error("Invalid input!");
    }

    this.availableCars.push({
      model,
      horsepower,
      price,
      mileage,
    });

    return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(
      2
    )} km - ${price.toFixed(2)}$`;
  }

  sellCar(model, desiredMileage) {
    const targetCarIndex = this.availableCars.findIndex(
      (x) => x.model === model
    );

    if (targetCarIndex === -1) {
      throw new Error(`${model} was not found!`);
    }

    const targetCar = this.availableCars.find((x) => x.model === model);
    let price = targetCar.price;

    if (
      targetCar.mileage - desiredMileage > 0 &&
      targetCar.mileage - desiredMileage <= 40000
    ) {
      price -= 0.05 * price;
    } else if (targetCar.mileage - desiredMileage > 40000) {
      price -= 0.1 * price;
    }

    this.availableCars.splice(targetCarIndex, 1);
    this.soldCars.push({
      model: targetCar.model,
      horsepower: targetCar.horsepower,
      soldPrice: price,
    });
    this.totalIncome += price;

    return `${targetCar.model} was sold for ${price.toFixed(2)}$`;
  }

  currentCar() {
    if (!this.availableCars.length) {
      return "There are no available cars";
    }

    const result = this.availableCars
      .map(
        (x) =>
          `---${x.model} - ${x.horsepower} HP - ${x.mileage.toFixed(
            2
          )} km - ${x.price.toFixed(2)}$`
      )
      .join("\n");

    return `-Available cars:\n${result}`;
  }

  salesReport(criteria) {
    if (criteria !== "horsepower" && criteria !== "model") {
      throw new Error("Invalid criteria!");
    }

    let sortedCars;

    if (criteria === "horsepower") {
      sortedCars = this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
    } else {
      sortedCars = this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
    }

    const result = sortedCars
      .map(
        (x) => `---${x.model} - ${x.horsepower} HP - ${x.soldPrice.toFixed(2)}$`
      )
      .join("\n");

    return `-${this.name} has a total income of ${this.totalIncome.toFixed(
      2
    )}$\n-${this.soldCars.length} cars sold:\n${result}`;
  }
}

let dealership = new CarDealership("SoftAuto");
console.log(dealership.addCar("Toyota Corolla", 100, 3500, 190000));
console.log(dealership.addCar("Mercedes C63", 300, 29000, 187000));
console.log(dealership.addCar("", 120, 4900, 240000));

// let dealership = new CarDealership("SoftAuto");
// dealership.addCar("Toyota Corolla", 100, 3500, 190000);
// dealership.addCar("Mercedes C63", 300, 29000, 187000);
// dealership.addCar("Audi A3", 120, 4900, 240000);
// console.log(dealership.sellCar("Toyota Corolla", 230000));
// console.log(dealership.sellCar("Mercedes C63", 110000));

// let dealership = new CarDealership("SoftAuto");
// dealership.addCar("Toyota Corolla", 100, 3500, 190000);
// dealership.addCar("Mercedes C63", 300, 29000, 187000);
// dealership.addCar("Audi A3", 120, 4900, 240000);
// console.log(dealership.currentCar());

// let dealership = new CarDealership("SoftAuto");
// dealership.addCar("Toyota Corolla", 100, 3500, 190000);
// dealership.addCar("Mercedes C63", 300, 29000, 187000);
// dealership.addCar("Audi A3", 120, 4900, 240000);
// dealership.sellCar("Toyota Corolla", 230000);
// dealership.sellCar("Mercedes C63", 110000);
// console.log(dealership.salesReport("horsepower"));
