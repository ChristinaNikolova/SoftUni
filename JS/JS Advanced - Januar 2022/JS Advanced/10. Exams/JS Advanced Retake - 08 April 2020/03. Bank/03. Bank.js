class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        if (this.allCustomers.some((x) => x.personalId === customer.personalId)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        customer.totalMoney = 0;
        customer.history = [];
        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find((x) => x.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        customer.totalMoney += Number(amount);
        customer.history.unshift(`${customer.history.length + 1}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);

        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        amount = Number(amount);
        let customer = this.allCustomers.find((x) => x.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        customer.history.unshift(`${customer.history.length + 1}. ${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find((x) => x.personalId === personalId);

        if (!customer) {
            throw new Error('We have no customer with this ID!');
        }

        let messageToReturn = `Bank name: ${this._bankName}\nCustomer name: ${customer.firstName} ${customer.lastName}\nCustomer ID: ${customer.personalId}\nTotal Money: ${customer.totalMoney}$\nTransactions:\n`;
        messageToReturn += customer.history.join('\n');

        return messageToReturn.trimEnd();
    }
}

let bank = new Bank('SoftUni Bank');
console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));
bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);
console.log(bank.withdrawMoney(6233267, 125));
console.log(bank.customerInfo(6233267)); 