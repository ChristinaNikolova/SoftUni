function solve(arr) {
    const result = arr
        .slice()
        .sort((a, b) => a.length - b.length || a.localeCompare(b))
        .join('\n');

    console.log(result);
}

solve(['alpha', 'beta', 'gamma']);
solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
solve(['test', 'Deny', 'omen', 'Default']);