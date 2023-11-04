function solve(numbers) {
    const smallestTwoNumbers = numbers
        .sort((a, b) => a - b)
        .slice(0, 2)
        .join(' ');

    console.log(smallestTwoNumbers);
}

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);