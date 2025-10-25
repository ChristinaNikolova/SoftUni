class Garden {
  constructor(spaceAvailable) {
    this.spaceAvailable = spaceAvailable;
    this.plants = [];
    this.storage = [];
  }

  addPlant(plantName, spaceRequired) {
    if (this.spaceAvailable < spaceRequired) {
      throw new Error("Not enough space in the garden.");
    }

    this.plants.push({ plantName, spaceRequired, ripe: false, quantity: 0 });
    this.spaceAvailable -= spaceRequired;

    return `The ${plantName} has been successfully planted in the garden.`;
  }

  ripenPlant(plantName, quantity) {
    const targetPlant = this.getPlant(plantName);

    if (targetPlant.ripe) {
      throw new Error(`The ${plantName} is already ripe.`);
    }

    if (quantity <= 0) {
      throw new Error("The quantity cannot be zero or negative.");
    }

    targetPlant.ripe = true;
    targetPlant.quantity += quantity;

    return quantity === 1
      ? `${quantity} ${plantName} has successfully ripened.`
      : `${quantity} ${plantName}s have successfully ripened.`;
  }

  harvestPlant(plantName) {
    const targetPlant = this.getPlant(plantName);

    if (!targetPlant.ripe) {
      throw new Error(
        `The ${plantName} cannot be harvested before it is ripe.`
      );
    }

    this.plants = this.plants.filter((x) => x.plantName !== plantName);
    this.storage.push({ plantName, quantity: targetPlant.quantity });
    this.spaceAvailable += targetPlant.spaceRequired;

    return `The ${plantName} has been successfully harvested.`;
  }

  generateReport() {
    const sortedPlants = this.plants
      .sort((a, b) => a.plantName.localeCompare(b.plantName))
      .map((x) => x.plantName)
      .join(", ");

    const plantsInStorage = this.storage.length
      ? `Plants in storage: ${this.storage
          .map((x) => `${x.plantName} (${x.quantity})`)
          .join(", ")}`
      : "Plants in storage: The storage is empty.";

    return `The garden has ${this.spaceAvailable} free space left.\nPlants in the garden: ${sortedPlants}\n${plantsInStorage}`;
  }

  getPlant(plantName) {
    const targetPlant = this.plants.find((x) => x.plantName === plantName);

    if (!targetPlant) {
      throw new Error(`There is no ${plantName} in the garden.`);
    }

    return targetPlant;
  }
}

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant("apple", 20));
// console.log(myGarden.addPlant("orange", 200));
// console.log(myGarden.addPlant("olive", 50));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant("apple", 20));
// console.log(myGarden.addPlant("orange", 100));
// console.log(myGarden.addPlant("cucumber", 30));
// console.log(myGarden.ripenPlant("apple", 10));
// console.log(myGarden.ripenPlant("orange", 1));
// console.log(myGarden.ripenPlant("orange", 4));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant("apple", 20));
// console.log(myGarden.addPlant("orange", 100));
// console.log(myGarden.addPlant("cucumber", 30));
// console.log(myGarden.ripenPlant("apple", 10));
// console.log(myGarden.ripenPlant("orange", 1));
// console.log(myGarden.ripenPlant("olive", 30));

// const myGarden = new Garden(250)
// console.log(myGarden.addPlant('apple', 20));
// console.log(myGarden.addPlant('orange', 100));
// console.log(myGarden.addPlant('cucumber', 30));
// console.log(myGarden.ripenPlant('apple', 10));
// console.log(myGarden.ripenPlant('orange', 1));
// console.log(myGarden.ripenPlant('cucumber', -5));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant("apple", 20));
// console.log(myGarden.addPlant("orange", 200));
// console.log(myGarden.addPlant("raspberry", 10));
// console.log(myGarden.ripenPlant("apple", 10));
// console.log(myGarden.ripenPlant("orange", 1));
// console.log(myGarden.harvestPlant("apple"));
// console.log(myGarden.harvestPlant("olive"));

// const myGarden = new Garden(250);
// console.log(myGarden.addPlant("apple", 20));
// console.log(myGarden.addPlant("orange", 200));
// console.log(myGarden.addPlant("raspberry", 10));
// console.log(myGarden.ripenPlant("apple", 10));
// console.log(myGarden.ripenPlant("orange", 1));
// console.log(myGarden.harvestPlant("apple"));
// console.log(myGarden.harvestPlant("raspberry"));

const myGarden = new Garden(250);
console.log(myGarden.addPlant("apple", 20));
console.log(myGarden.addPlant("orange", 200));
console.log(myGarden.addPlant("raspberry", 10));
console.log(myGarden.ripenPlant("apple", 10));
console.log(myGarden.ripenPlant("orange", 1));
console.log(myGarden.harvestPlant("orange"));
console.log(myGarden.generateReport());
