class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        products.forEach((product) => {
            let [productName, productQuantity, productTotalPrice] = product.split(' ').map((x) => x.trim());
            productQuantity = Number(productQuantity);
            productTotalPrice = Number(productTotalPrice);

            if (this.budgetMoney < productTotalPrice) {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            } else {
                if (!this.stockProducts.hasOwnProperty(productName)) {
                    this.stockProducts[productName] = 0;
                }

                this.stockProducts[productName] += productQuantity;
                this.budgetMoney -= productTotalPrice;
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            }
        });

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        price = Number(price);

        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        this.menu[meal] = {
            products: neededProducts,
            price,
        };

        let mealsCount = Object.keys(this.menu).length;

        if (mealsCount === 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }

        return `Great idea! Now with the ${meal} we have ${mealsCount} meals in the menu, other ideas?`;
    }

    showTheMenu() {
        if (Object.keys(this.menu).length === 0) {
            return 'Our menu is not ready yet, please come later...';
        }

        let messageToReturn = Object.keys(this.menu)
            .map((meal) => `${meal} - $ ${this.menu[meal].price}`)
            .join('\n');

        return messageToReturn.trimEnd();
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;
        let canPrepare = true;

        neededProducts.forEach((product) => {
            let [productName, productQuantity] = product.split(' ').map((x) => x.trim());
            productQuantity = Number(productQuantity);

            if (!this.stockProducts.hasOwnProperty(productName) || this.stockProducts[productName] < productQuantity) {
                canPrepare = false;
            }
        });

        if (!canPrepare) {
            return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
        }

        for (const product of neededProducts) {
            let [productName, productQuantity] = product.split(' ').map((x) => x.trim());
            productQuantity = Number(productQuantity);
            this.stockProducts[productName] -= productQuantity;
        }

        const price = this.menu[meal].price;
        this.budgetMoney += price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${price}.`;
    }
}

// let kitchen = new Restaurant(1000);
// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

// let kitchen = new Restaurant(1000);
// console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
// console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));
// console.log(kitchen.showTheMenu()); 

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt')); 