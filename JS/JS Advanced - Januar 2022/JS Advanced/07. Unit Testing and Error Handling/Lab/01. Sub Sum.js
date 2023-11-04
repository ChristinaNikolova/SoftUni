function solve(numbers, start, end) {
    if (!Array.isArray(numbers)) {
        return NaN;
    }

    const startIndex = Math.max(start, 0);
    const endIndex = Math.min(end, numbers.length - 1);

    const sum = numbers
        .slice(startIndex, endIndex + 1)
        .reduce((acc, curr) => {
            return acc + Number(curr);
        }, 0);

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));