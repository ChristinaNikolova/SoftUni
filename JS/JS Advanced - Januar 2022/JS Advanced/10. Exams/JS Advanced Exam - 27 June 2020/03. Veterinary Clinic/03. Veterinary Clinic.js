class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.currentTakenPlaces = 0;
        this.totalProfit = 0;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        if (this.currentTakenPlaces === this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        let owner = this.clients.find((x) => x.ownerName === ownerName);

        if (owner && owner.pets.some((x) => x.petName === petName && x.procedures.length > 0)) {
            const procedures = owner.pets.find((x) => x.petName === petName).procedures;

            throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${procedures.join(', ')}.`);
        }

        if (!owner) {
            owner = {
                ownerName,
                pets: [],
            };

            this.clients.push(owner);
        }

        let pet = {
            petName,
            kind: kind.toLowerCase(),
            procedures,
        };

        owner.pets.push(pet);
        this.currentTakenPlaces++;

        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        let owner = this.clients.find((x) => x.ownerName === ownerName);

        if (!owner) {
            throw new Error('Sorry, there is no such client!');
        }

        let pet = owner.pets.find((x) => x.petName === petName);

        if (!pet || pet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        const currentBill = pet.procedures.length * 500;
        this.totalProfit += currentBill;
        this.currentTakenPlaces--;
        pet.procedures = [];

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString() {
        let bussinessInPercentage = Math.floor(this.currentTakenPlaces / this.capacity * 100);
        let messageToReturn = `${this.clinicName} is ${ bussinessInPercentage }% busy today!\nTotal profit: ${this.totalProfit.toFixed(2)}$\n`;

        this.clients
            .sort((a, b) => a.ownerName.localeCompare(b.ownerName))
            .forEach((client) => {
                messageToReturn += `${client.ownerName} with:\n`;

                client.pets
                    .sort((a, b) => a.petName.localeCompare(b.petName))
                    .forEach((pet) => {
                        messageToReturn += `---${ pet.petName } - a ${pet.kind } that needs: ${pet.procedures.join(', ')}\n`;
                    });
            });

        return messageToReturn.trimEnd();
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString()); 
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);  
console.log(clinic.toString()); 