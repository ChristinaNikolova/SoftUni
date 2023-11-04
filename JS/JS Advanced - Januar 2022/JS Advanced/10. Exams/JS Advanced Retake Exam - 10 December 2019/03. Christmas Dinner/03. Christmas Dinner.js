class ChristmasDinner {
    constructor(budget) {
        if (budget < 0) {
            throw new Error('The budget cannot be a negative number');
        }

        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    shopping(product) {
        let [type, price] = product;
        price = Number(price);

        if (this.budget < price) {
            throw new Error('Not enough money to buy this product');
        }

        this.products.push(type);
        this.budget -= price;

        return `You have successfully bought ${type}!`;
    }

    recipes(recipe) {
        const neededProducts = recipe.productsList;
        let canPrepare = true;

        neededProducts.forEach((product) => {
            if (!this.products.includes(product)) {
                canPrepare = false;
            }
        });

        if (!canPrepare) {
            throw new Error('We do not have this product');
        }

        this.dishes.push(recipe);

        return `${recipe.recipeName} has been successfully cooked!`;
    }

    inviteGuests(name, dish) {
        if (!this.dishes.some((x) => x.recipeName === dish)) {
            throw new Error('We do not have this dish');
        }

        if (this.guests.hasOwnProperty(name)) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = dish;

        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let messageToreturn = '';

        Object.keys(this.guests).forEach((guest) => {
            const dish = this.guests[guest];
            const products = this.dishes.find((x) => x.recipeName === dish).productsList;

            messageToreturn += `${guest} will eat ${dish}, which consists of ${products.join(', ')}\n`;
        });

        return messageToreturn.trimEnd();
    }
}

let dinner = new ChristmasDinner(300);
console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));

console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
}));

console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
}));

console.log(dinner.inviteGuests('Ivan', 'Oshav'));
console.log(dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice'));
console.log(dinner.inviteGuests('Georgi', 'Peppers filled with beans'));
console.log(dinner.showAttendance()); 