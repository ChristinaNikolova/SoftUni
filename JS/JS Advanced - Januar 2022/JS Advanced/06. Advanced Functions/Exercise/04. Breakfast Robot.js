function solution() {
    const elements = {
        'protein': 0,
        'carbohydrate': 0,
        'fat': 0,
        'flavour': 0,
    };

    const meals = {
        'apple': {
            'carbohydrate': 1,
            'flavour': 2,
        },
        'lemonade': {
            'carbohydrate': 10,
            'flavour': 20,
        },
        'burger': {
            'carbohydrate': 5,
            'fat': 7,
            'flavour': 3,
        },
        'eggs': {
            'protein': 5,
            'fat': 1,
            'flavour': 1,
        },
        'turkey': {
            'protein': 10,
            'carbohydrate': 10,
            'fat': 10,
            'flavour': 10,
        },
    };

    function manager(input) {
        let [command, element, quantity] = input.split(' ').map((x) => x.trim());

        if (command === 'restock') {
            elements[element] += Number(quantity);
            return 'Success';
        } else if (command === 'prepare') {
            const ingridients = meals[element];
            let canPrepare = true;
            let neededIngridients = [];

            Object.keys(ingridients).forEach((ing) => {
                const neededQunatity = ingridients[ing] * Number(quantity);

                if (neededQunatity > elements[ing]) {
                    canPrepare = false;
                    neededIngridients.push(ing);
                }
            });

            if (!canPrepare) {
                const firstNeededIng = neededIngridients.shift();
                return `Error: not enough ${firstNeededIng} in stock`;
            }

            Object.keys(ingridients).forEach((ing) => {
                elements[ing] -= ingridients[ing] * Number(quantity);
            });

            return 'Success';
        } else if (command === 'report') {
            const message = Object.keys(elements).reduce((acc, curr) => {
                acc += `${curr}=${elements[curr]} `;
                return acc;
            }, '');

            return message.trimEnd();
        }
    }

    return manager.bind(this);
}

let manager = solution();
// console.log(manager('restock flavour 50')); // Success  
// console.log(manager('prepare lemonade 4')); // Error: not enough carbohydrate in stock  

// console.log(manager('restock flavour 50'));
// console.log(manager('prepare lemonade 4'));
// console.log(manager('restock carbohydrate 10'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare burger 1'));
// console.log(manager('report'));

console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));