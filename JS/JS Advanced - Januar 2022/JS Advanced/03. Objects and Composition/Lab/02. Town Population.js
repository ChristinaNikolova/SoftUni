function solve(input) {
    const towns = input.reduce((acc, curr) => {
        let [name, population] = curr.split('<->').map((x) => x.trim());
        population = Number(population);

        if (!acc.hasOwnProperty(name)) {
            acc[name] = 0;
        }

        acc[name] += population;

        return acc;
    }, {});

    let messageToPrint = '';

    Object.keys(towns).forEach((town) => {
        messageToPrint += `${town} : ${towns[town]}\n`;
    });

    console.log(messageToPrint.trimEnd());
}

solve(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);

solve(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']);