function solve(names) {
    const sortedNames = names
        .slice()
        .sort((a, b) => a.localeCompare(b))
        .map((x, i) => `${i + 1}.${x}`)
        .join('\n');

    console.log(sortedNames);
}

solve(["John", "Bob", "Christina", "Ema"]);