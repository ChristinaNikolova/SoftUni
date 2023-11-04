function solve(...input) {
    const result = input.reduce((acc, curr) => {
        const type = typeof curr;

        if (!acc.hasOwnProperty(type)) {
            acc[type] = 0;
        }

        acc[type]++;

        console.log(`${type}: ${curr}`);

        return acc;
    }, {});

    const sortedResult = Object.keys(result)
        .sort((a, b) => result[b] - result[a])
        .map((x) => `${x} = ${result[x]}`)
        .join('\n');

    console.log(sortedResult.trimEnd());
}

solve('cat', 42, function () { console.log('Hello world!'); });