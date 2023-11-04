function solve(size = 5) {
    const symbol = '* ';
    let result = '';

    for (let i = 0; i < size; i++) {
        result += symbol.repeat(size).trimEnd() + '\n';
    }

    console.log(result.trimEnd());
}

solve(1);
solve(2);
solve(5);
solve(7);
solve();