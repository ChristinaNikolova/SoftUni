function solve(numbers) {
    const sum = () => numbers.reduce((acc, curr) => {
        return acc + curr;
    }, 0);

    const inverseSum = () => numbers.reduce((acc, curr) => {
        return acc + 1 / curr;
    }, 0);

    const concat = () => numbers.reduce((acc, curr) => {
        return acc + curr;
    }, '');

    console.log(sum());
    console.log(inverseSum());
    console.log(concat());
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);