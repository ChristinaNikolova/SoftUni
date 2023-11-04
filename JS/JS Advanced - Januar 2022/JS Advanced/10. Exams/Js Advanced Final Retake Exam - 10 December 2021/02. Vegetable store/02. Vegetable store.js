class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        let types = [];

        vegetables.forEach((current) => {
            let [type, quantity, price] = current.split(' ').map((x) => x.trim());
            quantity = Number(quantity);
            price = Number(price);

            let vegetable = this.availableProducts.find((x) => x.type === type);

            if (!vegetable) {
                vegetable = {
                    type,
                    price,
                    quantity,
                };

                this.availableProducts.push(vegetable);
            } else {
                vegetable.quantity += quantity;

                if (vegetable.price < price) {
                    vegetable.price = price;
                }
            }

            if (!types.includes(type)) {
                types.push(type);
            }
        });

        return `Successfully added ${types.join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        selectedProducts.forEach((current) => {
            let [type, quantity] = current.split(' ').map((x) => x.trim());
            quantity = Number(quantity);

            let vegie = this.availableProducts.find((x) => x.type === type)

            if (!vegie) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if (vegie.quantity < quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            totalPrice += vegie.price * quantity;
            vegie.quantity -= quantity;
        });

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {
        quantity = Number(quantity);
        let vegie = this.availableProducts.find((x) => x.type === type);

        if (!vegie) {
            throw new Error(`${type} is not available in the store.`);
        }

        if (vegie.quantity < quantity) {
            vegie.quantity = 0;

            return `The entire quantity of the ${type} has been removed.`;
        }

        vegie.quantity -= quantity;

        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        let messageToReturn = 'Available vegetables:\n';

        this.availableProducts
            .sort((a, b) => a.price - b.price)
            .map((x) => messageToReturn += `${x.type}-${x.quantity}-$${x.price}\n`);

        messageToReturn += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;

        return messageToReturn.trimEnd();
    }
}

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"])); 

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.buyingVegetables(["Okra 1"]));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));
// console.log(vegStore.buyingVegetables(["Banana 1", "Beans 2"])); 

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.rottingVegetable("Okra", 1));
// console.log(vegStore.rottingVegetable("Okra", 2.5));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"])); 

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision()); 