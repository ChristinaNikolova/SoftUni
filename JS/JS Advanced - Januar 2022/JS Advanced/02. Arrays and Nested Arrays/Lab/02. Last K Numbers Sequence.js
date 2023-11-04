function solve(n, k) {
    let numbers = [];

    for (let i = 0; i < n; i++) {
        if (i === 0) {
            numbers.push(1);
            continue;
        }

        const startIndex = i <= k ? 0 : i - k;

        const numbersToSum = numbers.slice(startIndex, startIndex + k);
        const currentNum = numbersToSum.reduce((acc, curr) => {
            return acc + curr;
        }, 0);

        numbers.push(currentNum);
    }

    return numbers;
}

console.log(solve(6, 3));
console.log(solve(8, 2));