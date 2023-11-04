function solve(input) {
    const products = input.reduce((acc, curr) => {
        let [town, product, price] = curr.split('|').map((x) => x.trim());
        price = Number(price);

        if (!acc.hasOwnProperty(product)) {
            acc[product] = {
                town,
                price,
            };
        }

        if (acc[product].price > price) {
            acc[product].price = price;
            acc[product].town = town;
        }

        return acc;
    }, {});

    let messageToPrint = '';

    Object.keys(products).forEach((key) => {
        messageToPrint += `${key} -> ${products[key].price} (${products[key].town})\n`;
    });

    console.log(messageToPrint.trimEnd());
}

solve(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);