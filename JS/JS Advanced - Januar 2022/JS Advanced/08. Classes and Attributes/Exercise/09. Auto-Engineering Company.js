function solve(input) {
    const result = input.reduce((acc, curr) => {
        let [brand, model, quantity] = curr.split('|').map((x) => x.trim());
        quantity = Number(quantity);

        if (!acc.hasOwnProperty(brand)) {
            acc[brand] = {};
        }

        if (!acc[brand].hasOwnProperty(model)) {
            acc[brand][model] = 0;
        }

        acc[brand][model] += quantity;

        return acc;
    }, {});

    let messageToPrint = '';

    Object.keys(result).forEach((brand) => {
        messageToPrint += `${brand}\n`;

        Object.keys(result[brand]).forEach((model) => {
            messageToPrint += `###${model} -> ${result[brand][model]}\n`;
        });
    });

    console.log(messageToPrint.trimEnd());
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);