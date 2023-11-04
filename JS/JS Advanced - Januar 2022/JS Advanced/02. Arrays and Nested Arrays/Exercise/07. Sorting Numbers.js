function solve(numbers) {
    const ascOrder = numbers
        .slice()
        .sort((a, b) => a - b);

    const descOrder = numbers
        .slice()
        .sort((a, b) => b - a);

    const isEven = numbers.length % 2 === 0;
    const interations = isEven ? numbers.length / 2 : Math.ceil(numbers.length / 2);
    let result = [];

    for (let i = 0; i < interations; i++) {
        result.push(ascOrder[i]);
        result.push(descOrder[i]);

        if (i + 1 === interations && !isEven) {
            result.pop();
        }
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));