class FlightBookingSystem {
  constructor(agencyName) {
    this.agencyName = agencyName;
    this.flights = [];
    this.bookings = [];
    this.bookingsCount = 0;
  }

  addFlight(flightNumber, destination, departureTime, price) {
    if (this.flights.some((x) => x.flightNumber === flightNumber)) {
      return `Flight ${flightNumber} to ${destination} is already available.`;
    }

    this.flights.push({
      flightNumber,
      destination,
      departureTime,
      price,
    });

    return `Flight ${flightNumber} to ${destination} has been added to the system.`;
  }

  bookFlight(passengerName, flightNumber) {
    if (!this.flights.some((x) => x.flightNumber === flightNumber)) {
      return `Flight ${flightNumber} is not available for booking.`;
    }

    this.bookings.push({
      passengerName,
      flightNumber,
    });
    this.bookingsCount++;

    return `Booking for passenger ${passengerName} on flight ${flightNumber} is confirmed.`;
  }

  cancelBooking(passengerName, flightNumber) {
    const targetBookingIndex = this.bookings.findIndex(
      (x) =>
        x.passengerName === passengerName && x.flightNumber === flightNumber
    );

    if (targetBookingIndex === -1) {
      throw new Error(
        `Booking for passenger ${passengerName} on flight ${flightNumber} not found.`
      );
    }

    this.bookings.splice(targetBookingIndex, 1);
    this.bookingsCount--;

    return `Booking for passenger ${passengerName} on flight ${flightNumber} is cancelled.`;
  }

  showBookings(criteria) {
    if (!this.bookings.length) {
      throw new Error("No bookings have been made yet.");
    }

    if (criteria === "all") {
      const bookings = this.bookings
        .map((x) => `${x.passengerName} booked for flight ${x.flightNumber}.`)
        .join("\n");

      return `All bookings(${this.bookingsCount}):\n${bookings}`;
    }

    if (criteria === "cheap") {
      const cheapFlights = this.flights.filter((x) => x.price <= 100);

      if (
        !this.bookings.some((x) =>
          cheapFlights.find((y) => y.flightNumber === x.flightNumber)
        )
      ) {
        return "No cheap bookings found.";
      }

      const bookings = this.bookings
        .filter((x) =>
          cheapFlights.find((y) => y.flightNumber === x.flightNumber)
        )
        .map((x) => `${x.passengerName} booked for flight ${x.flightNumber}.`)
        .join("\n");

      return `Cheap bookings:\n${bookings}`;
    }

    if (criteria === "expensive") {
      const expensiveFlights = this.flights.filter((x) => x.price > 100);

      if (
        !this.bookings.some((x) =>
          expensiveFlights.find((y) => y.flightNumber === x.flightNumber)
        )
      ) {
        return "No expensive bookings found.";
      }

      const bookings = this.bookings
        .filter((x) =>
          expensiveFlights.find((y) => y.flightNumber === x.flightNumber)
        )
        .map((x) => `${x.passengerName} booked for flight ${x.flightNumber}.`)
        .join("\n");

      return `Expensive bookings:\n${bookings}`;
    }
  }
}

// const system = new FlightBookingSystem("TravelWorld");
// console.log(system.addFlight("AA101", "Los Angeles", "09:00 AM", 250));
// console.log(system.addFlight("BB202", "New York", "10:30 AM", 180));
// console.log(system.addFlight("CC303", "Chicago", "11:45 AM", 120));
// console.log(system.addFlight("AA101", "Los Angeles", "09:00 AM", 250));

// const system = new FlightBookingSystem("TravelWorld");
// console.log(system.addFlight("AA101", "Los Angeles", "09:00 AM", 250));
// console.log(system.addFlight("BB202", "New York", "10:30 AM", 180));
// console.log(system.bookFlight("Alice", "AA101"));
// console.log(system.bookFlight("Bob", "BB202"));
// console.log(system.bookFlight("Charlie", "CC303"));

// const system = new FlightBookingSystem("TravelWorld");
// console.log(system.addFlight("AA101", "Los Angeles", "09:00 AM", 250));
// console.log(system.addFlight("BB202", "New York", "10:30 AM", 180));
// console.log(system.bookFlight("Alice", "AA101"));
// console.log(system.bookFlight("Bob", "BB202"));
// console.log(system.cancelBooking("Alice", "AA101"));

// const system = new FlightBookingSystem("TravelWorld");
// console.log(system.addFlight("AA101", "Los Angeles", "09:00 AM", 250));
// console.log(system.addFlight("BB202", "New York", "10:30 AM", 99));
// console.log(system.bookFlight("Alice", "AA101"));
// console.log(system.bookFlight("Bob", "BB202"));
// console.log(system.showBookings("all"));

const system = new FlightBookingSystem("TravelWorld");
console.log(system.addFlight("AA101", "Los Angeles", "09:00 AM", 250));
console.log(system.addFlight("BB202", "New York", "10:30 AM", 180));
console.log(system.bookFlight("Alice", "AA101"));
console.log(system.bookFlight("Bob", "BB202"));
console.log(system.showBookings("expensive"));
console.log(system.showBookings("cheap"));
