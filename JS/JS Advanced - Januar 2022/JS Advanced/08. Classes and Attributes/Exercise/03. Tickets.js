function solve(input, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = input.reduce((acc, curr) => {
        let [destination, price, status] = curr.split('|').map((x) => x.trim());
        price = Number(price);

        const ticket = new Ticket(destination, price, status);
        acc.push(ticket);

        return acc;
    }, []);

    tickets.sort((a, b) => {
        if (criteria === 'price') {
            return a[criteria] - b[criteria];
        }

        return a[criteria].localeCompare(b[criteria]);
    });

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'));

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'));