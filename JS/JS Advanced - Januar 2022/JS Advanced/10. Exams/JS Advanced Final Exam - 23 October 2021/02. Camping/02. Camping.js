class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            'child': 150,
            'student': 300,
            'collegian': 500,
        };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        money = Number(money);

        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        if (this.listOfParticipants.some((x) => x.name === name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (this.priceForTheCamp[condition] > money) {
            return 'The money is not enough to pay the stay at the camp.';
        }

        let participant = {
            name,
            condition,
            power: 100,
            wins: 0,
        };

        this.listOfParticipants.push(participant);

        return `The ${name} was successfully registered.`;
    }

    unregisterParticipant(name) {
        let participantIndex = this.listOfParticipants.findIndex((x) => x.name === name);

        if (participantIndex === -1) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants.splice(participantIndex, 1);

        return `The ${name} removed successfully.`;
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        let firstPlayer = this.listOfParticipants.find((x) => x.name === participant1);
        let secondPlayer = this.listOfParticipants.find((x) => x.name === participant2);

        if (!firstPlayer || (participant2 && !secondPlayer)) {
            throw new Error('Invalid entered name/s.');
        }

        if (participant2 && (firstPlayer.condition !== secondPlayer.condition)) {
            throw new Error('Choose players with equal condition.');
        }

        if (typeOfGame === 'Battleship') {
            firstPlayer.power += 20;

            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        }

        if (typeOfGame === 'WaterBalloonFights') {
            let messageToReturn = '';

            if (firstPlayer.power > secondPlayer.power) {
                firstPlayer.wins++;
                messageToReturn = `The ${participant1} is winner in the game ${typeOfGame}.`;
            } else if (firstPlayer.power < secondPlayer.power) {
                secondPlayer.wins++;
                messageToReturn = `The ${participant2} is winner in the game ${typeOfGame}.`;
            } else {
                messageToReturn = 'There is no winner.';
            }

            return messageToReturn;
        }
    }

    toString() {
        let messageToReturn = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        this.listOfParticipants
            .sort((a, b) => b.wins - a.wins)
            .map((x) => messageToReturn += `${x.name} - ${x.condition} - ${x.power} - ${x.wins}\n`);

        return messageToReturn.trimEnd();
    }
}

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.unregisterParticipant("Petar"));
// console.log(summerCamp.unregisterParticipant("Petar Petarson"));

// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov")); 

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));
console.log(summerCamp.toString()); 