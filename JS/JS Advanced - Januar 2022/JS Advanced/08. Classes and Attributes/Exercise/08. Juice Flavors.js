function solve(input) {
    let bottles = {};

    input.reduce((acc, curr) => {
        let [fruit, quantity] = curr.split('=>').map((x) => x.trim());
        quantity = Number(quantity);

        if (!acc.hasOwnProperty(fruit)) {
            acc[fruit] = 0;
        }

        acc[fruit] += quantity;

        if (acc[fruit] >= 1000) {
            if (!bottles.hasOwnProperty(fruit)) {
                bottles[fruit] = 0;
            }

            const currentBottles = parseInt(acc[fruit] / 1000);
            bottles[fruit] += currentBottles;
            acc[fruit] -= currentBottles * 1000;
        }

        return acc;
    }, {});

    let message = '';

    Object.keys(bottles).forEach((bottle) => {
        message += `${bottle} => ${bottles[bottle]}\n`;
    });

    console.log(message.trimEnd());
}

solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']);

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);