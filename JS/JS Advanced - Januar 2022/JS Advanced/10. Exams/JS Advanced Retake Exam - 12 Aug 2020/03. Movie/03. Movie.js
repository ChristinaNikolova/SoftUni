class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.screenings = [];
        this.totalProfit = 0;
        this.totalSoldTickets = 0;
    }

    newScreening(date, hall, description) {
        if (this.screenings.some((x) => x.date === date && x.hall === hall)) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        }

        let screening = {
            date,
            hall,
            description,
        };

        this.screenings.push(screening);

        return `New screening of ${this.movieName} is added.`;
    }

    endScreening(date, hall, soldTickets) {
        let screeningIndex = this.screenings.findIndex((x) => x.date === date && x.hall === hall);

        if (screeningIndex === -1) {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        }

        const currentProfit = soldTickets * this.ticketPrice;
        this.totalProfit += currentProfit;
        this.totalSoldTickets += soldTickets;

        this.screenings.splice(screeningIndex, 1);

        return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}`;
    }

    toString() {
        let messageToReturn = `${this.movieName} full information:\nTotal profit: ${this.totalProfit.toFixed(0)}$\nSold Tickets: ${this.totalSoldTickets}\n`;

        if (this.screenings.length > 0) {
            messageToReturn += 'Remaining film screenings:\n';

            this.screenings
                .sort((a, b) => a.hall.localeCompare(b.hall))
                .map((x) => messageToReturn += `${x.hall} - ${x.date} - ${x.description}\n`);
        } else {
            messageToReturn += 'No more screenings!';
        }


        return messageToReturn.trimEnd();
    }
}

let m = new Movie('Wonder Woman 1984', '10.00');
console.log(m.newScreening('October 2, 2020', 'IMAX 3D', `3D`));
console.log(m.newScreening('October 3, 2020', 'Main', `regular`));
console.log(m.newScreening('October 4, 2020', 'IMAX 3D', `3D`));
console.log(m.endScreening('October 2, 2020', 'IMAX 3D', 150));
console.log(m.endScreening('October 3, 2020', 'Main', 78));
console.log(m.toString());
m.newScreening('October 4, 2020', '235', `regular`);
m.newScreening('October 5, 2020', 'Main', `regular`);
m.newScreening('October 3, 2020', '235', `regular`);
m.newScreening('October 4, 2020', 'Main', `regular`);
console.log(m.toString()); 