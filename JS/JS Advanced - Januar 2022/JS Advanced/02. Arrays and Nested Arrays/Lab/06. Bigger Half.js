function solve(numbers) {
    const startIndex = numbers.length % 2 === 0 ? numbers.length / 2 : Math.floor(numbers.length / 2);
    const result = numbers
        .sort((a, b) => a - b)
        .slice(startIndex);

    return result;
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));