function solve(...numbers) {
    const largestNumber = Math.max(...numbers);
    console.log(`The largest number is ${largestNumber}.`);
}

solve(5, -3, 16);
solve(-3, -5, -22.5)