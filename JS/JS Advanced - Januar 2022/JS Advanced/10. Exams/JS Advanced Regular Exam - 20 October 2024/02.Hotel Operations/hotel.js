class Hotel {
  constructor(initialBudget) {
    this.initialBudget = initialBudget;
    this.roomAvailability = {};
    this.supplyStock = {};
    this.roomTypesCount = 0;
  }

  restockSupplies(supplies) {
    const result = supplies.reduce((acc, curr) => {
      let [name, qty, totalPrice] = curr.split(" ").map((x) => x.trim());
      qty = Number(qty);
      totalPrice = Number(totalPrice);

      if (this.initialBudget < totalPrice) {
        acc.push(`There was not enough money to restock ${qty} ${name}`);
      } else {
        if (!this.supplyStock.hasOwnProperty(name)) {
          this.supplyStock[name] = 0;
        }

        this.supplyStock[name] += qty;
        this.initialBudget -= totalPrice;
        acc.push(`Successfully stocked ${qty} ${name}`);
      }

      return acc;
    }, []);

    return result.join("\n");
  }

  addRoomType(roomType, neededSupplies, pricePerNight) {
    if (this.roomAvailability.hasOwnProperty(roomType)) {
      return `The ${roomType} is already available in our hotel, try something different.`;
    }

    this.roomAvailability[roomType] = {
      neededSupplies,
      pricePerNight,
    };
    this.roomTypesCount++;

    return `Great idea! Now with the ${roomType}, we have ${this.roomTypesCount} types of rooms available, any other ideas?`;
  }

  showAvailableRooms() {
    if (this.roomTypesCount === 0) {
      return "Our rooms are not ready yet, please come back later...";
    }

    return Object.keys(this.roomAvailability)
      .map((x) => `${x} - $ ${this.roomAvailability[x].pricePerNight}`)
      .join("\n");
  }

  bookRoom(roomType) {
    if (!this.roomAvailability.hasOwnProperty(roomType)) {
      return `There is no ${roomType} available, would you like to book another room?`;
    }

    const { neededSupplies, pricePerNight } = this.roomAvailability[roomType];

    for (const curr of neededSupplies) {
      const [name, qty] = curr.split(" ").map((x) => x.trim());

      if (
        !this.supplyStock.hasOwnProperty(name) ||
        this.supplyStock[name] < Number(qty)
      ) {
        return `We are currently unable to accommodate your request for ${roomType}, sorry for the inconvenience.`;
      }
    }

    neededSupplies.forEach((curr) => {
      const [name, qty] = curr.split(" ").map((x) => x.trim());
      this.supplyStock[name] -= Number(qty);
    });

    this.initialBudget += pricePerNight;
    return `Your booking for ${roomType} has been confirmed! The price is $${pricePerNight} per night.`;
  }
}

// let hotel = new Hotel(500);
// console.log(
//   hotel.restockSupplies(["Soap 100 50", "Towels 20 100", "Shampoo 50 75"])
// );

// let hotel = new Hotel(500);
// console.log(
//   hotel.restockSupplies(["Soap 100 50", "Towels 20 100", "Shampoo 50 75"])
// );
// console.log(hotel.addRoomType("Deluxe Suite", ["Soap 5", "Towels 2"], 200));
// console.log(hotel.addRoomType("Standard Room", ["Soap 2", "Towels 1"], 100));
// console.log(hotel.addRoomType("Standard Room", ["Soap 2", "Towels 1"], 100));

// let hotel = new Hotel(500);
// console.log(
//   hotel.restockSupplies(["Soap 100 50", "Towels 20 100", "Shampoo 50 75"])
// );
// console.log(hotel.addRoomType("Deluxe Suite", ["Soap 5", "Towels 2"], 200));
// console.log(hotel.addRoomType("Standard Room", ["Soap 2", "Towels 1"], 100));
// console.log(hotel.showAvailableRooms());

let hotel = new Hotel(500);
console.log(
  hotel.restockSupplies(["Soap 100 50", "Towels 20 100", "Shampoo 50 75"])
);
console.log(hotel.addRoomType("Deluxe Suite", ["Soap 5", "Towels 2"], 200));
console.log(hotel.addRoomType("Standard Room", ["Soap 2", "Towels 1"], 100));
console.log(hotel.showAvailableRooms());
console.log(hotel.bookRoom("Apartment"));
console.log(hotel.bookRoom("Deluxe Suite"));
