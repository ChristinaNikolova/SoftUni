function solve(numbers, criteria) {
    const sortCriteria = {
        'asc': (a, b) => a - b,
        'desc': (a, b) => b - a,
    };

    const result = numbers.sort(sortCriteria[criteria]);
    return result;
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));