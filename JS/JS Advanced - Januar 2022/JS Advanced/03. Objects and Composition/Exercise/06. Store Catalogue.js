function solve(input) {
    const sortedInput = input.sort((a, b) => a.localeCompare(b));

    const catalogue = sortedInput.reduce((acc, curr) => {
        let [name, price] = curr.split(':').map((x) => x.trim());
        price = Number(price);

        const firstLetter = name[0];

        if (!acc.hasOwnProperty(firstLetter)) {
            acc[firstLetter] = [];
        }

        acc[firstLetter].push({ name, price });

        return acc;
    }, {});

    let messageToPrint = '';

    Object.entries(catalogue).forEach((kvp) => {
        const letter = kvp[0];
        const products = kvp[1];

        messageToPrint += `${letter}\n`;

        products.forEach((product) => {
            messageToPrint += `  ${product.name}: ${product.price}\n`;
        });
    });

    console.log(messageToPrint.trimEnd());
}

solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);

solve(['Banana : 2',
    'Rubic\'s Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']);